using _1CommonInfrastructure.Interfaces;
using _3BusinessLogicLayer.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace _3BusinessLogicLayer.Services
{
    public class BaseService
    {
        protected readonly ISecurityService _securityService;
        protected readonly ILoggingService _loggingService;

        public BaseService(
            ISecurityService securityService
           ,ILoggingService loggingService
        )
        {
            _securityService = securityService;
            _loggingService = loggingService;
        }        

        protected async Task<bool> IsAuthorisedToAccess(params string[] actions)
        {
            var userSecurityModel = _securityService.GetUserSecuirty();
            if (!await _securityService.CheckUserActivity(actions))
            {
                throw new SecurityException("Un-authorised action");
            }
            return true;
        }

        // validations
        protected void CheckFluentValidation(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                throw new ArgumentException($"Validate information {string.Join("<br/>", validationResult.Errors)}");
            }
        }

        // Logger information
        protected void LogInformation(string keyArea, string message, object? data = null)
        {
            _loggingService.WriteLog(keyArea, message, data);
        }


        // Logger errors
        protected void LogError(string keyArea, string message, object? data = null, Exception ex = null)
        {
            _loggingService.WriteLog(keyArea, message, data, ex);
        }
    }
}