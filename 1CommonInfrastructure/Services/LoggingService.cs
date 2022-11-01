using _1CommonInfrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace _1CommonInfrastructure.Services
{
    public class LoggingService : ILoggingService
    {

        private readonly IUserNameResolver _userNameResolver;

        public LoggingService(IUserNameResolver userNameResolver)
        {
            _userNameResolver = userNameResolver;
        }

        public void WriteLog(string keyArea, string message, object additionalInfo = null, Exception ex = null)
        {
            var connectionString = "data source=.\\sqlexpress01;initial catalog=testdb27Sep22;integrated security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";//_configuration.GetSection("ConnectionStrings:ApplicationDB");                    

            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new List<SqlColumn>
                {
                    new SqlColumn { ColumnName = "Key", DataLength = 500, DataType = SqlDbType.NVarChar, AllowNull = false },
                    new SqlColumn { ColumnName = "UserId", DataLength = 100, DataType = SqlDbType.NVarChar, AllowNull = false },
                    new SqlColumn { ColumnName = "AdditionalInfo", DataType = SqlDbType.NVarChar }
                }
            };            

#if DEBUG
            Serilog.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));
#endif                         
            
            var log = new LoggerConfiguration()
                //.MinimumLevel.ControlledBy()
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(
                    connectionString: connectionString,
                    sinkOptions: new MSSqlServerSinkOptions { AutoCreateSqlTable = false, TableName = "LogEvents" },
                    columnOptions: columnOptions)
                .CreateLogger();            
            {
               
                    try
                    {                        
                        var userId = _userNameResolver.GetUsername();
                        var info = string.Empty;

                        if (additionalInfo != null)
                        {
                        //info = JsonConvert.SerializeObject(additionalInfo); 
                           info = JsonSerializer.Serialize(additionalInfo);
                        }

                    if (ex is null)
                    {
                        log.ForContext("Key", keyArea)
                             .ForContext("UserId", userId)
                             .ForContext("AdditionalInfo", info)
                             .Write(LogEventLevel.Information, message);
                    }
                    else
                    {
                        log.ForContext("Key", keyArea)
                             .ForContext("UserId", userId)
                             .ForContext("AdditionalInfo", info)
                             .Error(ex, message);
                    }                       

                    }
                    catch (Exception unhex)
                    {
                       throw new Exception("not hanlded in logging");
                    }                
            }
        }
    }
}
