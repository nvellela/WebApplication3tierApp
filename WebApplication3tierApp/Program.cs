using _2DataAccessLayer.Context;
using _4Bootstrap;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;
using FluentValidation.AspNetCore;
using System.Text.RegularExpressions;
using _1CommonInfrastructure.Validations;
using System.Net;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.Json.Serialization;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers((options) =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
})
  //  .AddNewtonsoftJson(options => options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc)
  //  .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new DateTimeConverter()))
    .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddFluentValidation(fluent => fluent.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


var projectDevelopmentCorsOptions = "_projectDevelopmentCorsOptions";
var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<DBEntitiesContext>(options => options.UseSqlServer(cnn, b => b.MigrationsAssembly("2DataAccessLayer")));

#region CUSTOM SERVICES [D-I]

Bootstrap.Initialize(builder.Services, builder.Configuration);

//builder.Services.AddScoped<IDataAccessService, DataAccessService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//services.AddScoped<IApplicant_Service, Applicant_Service>();
//services.AddScoped<IGrade_Service, Grade_Service>();
//services.AddScoped<IApplication_Service, Application_Service>();
//services.AddScoped<IApplicationStatus_Service, ApplicationStatus_Service>();
#endregion


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: projectDevelopmentCorsOptions, policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3033", "http://localhost:3034", "http://localhost:4173", "http://localhost:4200").AllowCredentials();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//init bootstrap services ...

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(projectDevelopmentCorsOptions);
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<ErrorReporterMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();


public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null)
        {
            return null;
        }

        // Slugify value
        return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}


public class ErrorReporterMiddleware
{
    private readonly RequestDelegate RequestDelegate;
    private readonly IWebHostEnvironment _environment;

    public ErrorReporterMiddleware(RequestDelegate requestDelegate, IWebHostEnvironment environment)
    {
        RequestDelegate = requestDelegate ?? throw new ArgumentNullException(nameof(requestDelegate));
        _environment = environment;
    }

    public async Task Invoke(HttpContext httpContext )
    {
        try
        {
            await RequestDelegate(httpContext);
        }
        catch (Exception ex)
        {
            await HandleException(httpContext,  ex);
        }
    }

    private Task HandleException(HttpContext httpContext,  Exception exception)
    {
       // errorReporter?.WriteLog(LoggingLevel.Error, ApplicationArea.UnhandledException, exception.Message, exception.StackTrace);

        var result = string.Empty;
        var statusCode = HttpStatusCode.InternalServerError;

        // HTTP 422 Unprocessable Entity response status code indicates that the server understands the content type of the
        // request entity, and the syntax of the request entity is correct, but it was unable to process the contained instructions.
        if (exception is FluentValidationException fex)
        {
            result = fex.ToJson();
            statusCode = HttpStatusCode.UnprocessableEntity;
        }
        else if (exception is ValidationException vex)
        {
            result = vex.ToJson();
            statusCode = HttpStatusCode.UnprocessableEntity;
        }     
        else if (_environment.IsDevelopment())
        {
            result = exception.ToString();
        }

        httpContext.Response.StatusCode = (int)statusCode;
        httpContext.Response.ContentType = "application/json";

        return httpContext.Response.WriteAsync(result);
    }
}