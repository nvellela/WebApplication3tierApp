using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using _1CommonInfrastructure.Enums;
using ValidationResult = FluentValidation.Results.ValidationResult;
using _1CommonInfrastructure.Validations;

namespace _3BusinessLogicLayer.Services
{
    public class BaseService
    {
        //protected readonly IUserSecurityService _userSecurityService;
        //protected readonly ILogService _logService;

        public BaseService(
            //IUserSecurityService userSecurityService,
            //ILogService loggingService
        )
        {
            //_userSecurityService = userSecurityService;
            //_logService = logService;
        }

        // Validation
        protected async Task<bool> ValidateBasicAccess()
        {
            //var user = await _userSecurityService.GetCurrentUserAuth();
            //if (user != null && user.IsValid())
            {
                return true;
            }
            return false;
        }

        protected async Task<bool> ValidateAccess(params SystemActions[] activities)
        {
            if(true == false) // (!await _userSecurityService.CurrentUserCanDoActivity(activities))
            {
                throw new SecurityException("Unauthorised access - action not allowed.");
            }
            return true;
        }

        // Checkers - Assertions
        protected void CheckFluentValidation(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException("Unable to validate information", validationResult);
            }
        }

        // Loggers
        protected void LogError(string message, object? data = null)
        {
           // _logService.WriteLog(LoggingLevel.Error, message, data);
        }
    }
}
