using _2DataAccessLayer.Context;
using _4Bootstrap;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Negotiate;
using WebApplication3tierApp.Controllers;
using _1CommonInfrastructure.Interfaces;
using Newtonsoft.Json.Serialization;
using _1CommonInfrastructure.Services;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var projectDevelopmentCorsOptions = "_projectDevelopmentCorsOptions";
var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<DBEntitiesContext>(options => options.UseSqlServer(cnn, b => b.MigrationsAssembly("2DataAccessLayer")));




builder.Services.AddCors(options =>
{
    options.AddPolicy(name: projectDevelopmentCorsOptions, policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3033", "http://localhost:3034", "http://localhost:4173", "http://localhost:4200").AllowCredentials();
    });
});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region CUSTOM SERVICES [D-I]

//add common services DI
builder.Services.AddTransient<ILoggingService, LoggingService>();
//IHttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserNameResolver, UserNameResolver>();


Bootstrap.Initialize(builder.Services, builder.Configuration);

//builder.Services.AddScoped<IDataAccessService, DataAccessService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//services.AddScoped<IApplicant_Service, Applicant_Service>();
//services.AddScoped<IGrade_Service, Grade_Service>();
//services.AddScoped<IApplication_Service, Application_Service>();
//services.AddScoped<IApplicationStatus_Service, ApplicationStatus_Service>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(projectDevelopmentCorsOptions);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<ExceptionHandlingMiddleware>();
var logger = app.Services.GetRequiredService<ILoggingService>();
app.ConfigureExceptionHandler(logger);

app.MapControllers();

app.Run();


public static class ExceptionMiddlewareExtensions
{
    //https://code-maze.com/global-error-handling-aspnetcore/
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggingService logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger.WriteLog("ExceptionMiddlewareExtensions", $"Something went wrong: {contextFeature.Error}", ex: contextFeature.Error);
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error."
                    }.ToString());
                }
            });
        });
    }
}

internal class ErrorDetails
{
    public ErrorDetails()
    {
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
}