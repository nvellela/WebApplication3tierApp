using _3BusinessLogicLayer.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace _3BusinessLogicLayer.Services
{
    public class BaseService
    {
        protected readonly ISecurityService _securityService;
       // protected readonly ILoggingService _loggingService;

        public BaseService(
            ISecurityService securityService
        // ,ILoggingService loggingService
        )
        {
            _securityService = securityService;
            //_loggingService = loggingService;
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

        //// Checkers - Assertions
        //protected void CheckFluentValidation(ValidationResult validationResult)
        //{
        //    if (!validationResult.IsValid)
        //    {
        //        throw new FluentValidationException("Unable to validate information", validationResult);
        //    }
        //}

        //// Loggers
        //protected void LogError(string message, object? data = null)
        //{
        //    _loggingService.WriteLog(LoggingLevel.Error, ApplicationArea.BusinessLogic, message, data);
        //}
    }
}