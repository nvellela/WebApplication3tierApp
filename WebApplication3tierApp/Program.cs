using _2DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cnn = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<DBEntitiesContext>(options => options.UseSqlServer(cnn, b => b.MigrationsAssembly("DLL")));

#region CUSTOM SERVICES [D-I]


//builder.Services.AddScoped<IDataAccessService, DataAccessService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//services.AddScoped<IApplicant_Service, Applicant_Service>();
//services.AddScoped<IGrade_Service, Grade_Service>();
//services.AddScoped<IApplication_Service, Application_Service>();
//services.AddScoped<IApplicationStatus_Service, ApplicationStatus_Service>();
#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
