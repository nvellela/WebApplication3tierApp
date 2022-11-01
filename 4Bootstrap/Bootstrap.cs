
using _2DataAccessLayer.Ioc;
using _3BusinessLogicLayer.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _4Bootstrap
{
    public static class Bootstrap
    {
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            // DB Connection            
            //services.AddScoped<Database>();

            //Add common service


            // Application Services                       
            _2DataAccessLayer.Ioc.Init.InitializeDependencies(services, configuration);
            _3BusinessLogicLayer.Ioc.Init.InitializeDependencies(services, configuration);

        }
    }
}
