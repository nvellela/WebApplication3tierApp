using _1CommonInfrastructure.Interfaces;
using _1CommonInfrastructure.Services;
using _3BusinessLogicLayer.Interfaces;
using _3BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3tierApp.Controllers
{    
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISecurityService _securityService;
        private readonly ILoggingService _loggingService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISecurityService securityService, ILoggingService loggingService) 
        {
            _logger = logger;
            _securityService= securityService;
            _loggingService = loggingService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var ss = _securityService.GetUserSecuirty();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetUserDetails", Name = "GetUserDetails")]
        public IActionResult GetUserDetails()
        {
            var ss = _securityService.GetUserSecuirty();

            _loggingService.WriteLog("GetUserDetails", "test", ss);

            _loggingService.WriteLog("GetUserDetails", "testError",ex: new Exception("testing exception"));
            return new JsonResult(ss);
        }


        [HttpGet("GetUserName", Name = "GetUserName")]
        public IActionResult GetUserName()
        {
            //throw new Exception("Exception while checking.");

            _loggingService.WriteLog("GetUserName", "test");
            var UserName = User.Identity.Name;
            return new JsonResult(UserName);
        }

    }
}