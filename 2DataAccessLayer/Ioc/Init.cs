using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _2DataAccessLayer.Ioc
{
    public static class Init
    {
        public static void InitializeDependencies(IServiceCollection services, IConfiguration configuration)
        {            
            //services.AddScoped<IAuditDal, AuditDal>();
            //services.AddScoped<IApplicationLogDal, ApplicationLogDal>();
            //services.AddScoped<IAuthDal, AuthDal>();
            //services.AddScoped<ICodeDal, CodeDal>();
            //services.AddScoped<IConfigurationDal, ConfigurationDal>();
            //services.AddScoped<IDocumentDataDal, DocumentDataDal>();
            //services.AddScoped<IDocumentDataTempDal, DocumentDataTempDal>();
            //services.AddScoped<IUserDal, UserDal>();
            
            services.AddScoped<IPersonDal, PersonDal>();
            services.AddScoped<IStudentDal, StudentDal>();
            services.AddScoped<IEmployeeDal, EmployeeDal>();

            services.AddScoped<ISecurityDal, SecurityDal>();
            

        }
    }
}
