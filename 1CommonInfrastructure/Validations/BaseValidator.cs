using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace _1CommonInfrastructure.Validations
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
    }


    public static class ValidatorMessage
    {
        public static string MaxLength(int maxLength) => $"exceeded maximum {maxLength} characters";

        public static string NotEmpty => $"cannot be empty";

        public static string EmailAddress => $"must be a valid email address with @";

        public static string PhoneNumber => $"must be a valid phone number ex 04123456";

    }


    public static class FluentValidationExtensions
    {
        public static IDictionary<string, string[]> ToDictionary(this ValidationResult validationResult)
        {
            return validationResult.Errors
              .GroupBy(x => x.PropertyName)
              .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
              );
        }

        public static string ToErrorMessage(this ValidationFailure src)
        {
            return $"{src.PropertyName} {src.ErrorMessage}";
        }

        public static List<string> ToErrorMessages(this List<ValidationFailure> src)
        {
            return src.Select(x => x.ToErrorMessage()).ToList();
        }
    }


    public class FluentValidationException : Exception
    {
        public List<string> Errors { get; set; } = new List<string>();


        public FluentValidationException()
        {
        }

        public FluentValidationException(string message, ValidationResult validationResult = null, Exception innerException = null)
            : base(message, innerException)
        {
            Errors = validationResult?.Errors.ToErrorMessages();
        }
    }


    public static class FluentValidationExceptionExtensions
    {
        public static string ToJson(this FluentValidationException ex)
        {
            return JsonConvert.SerializeObject(new
            {
                name = ex.Message,
                message = string.Join("<br/>", ex.Errors),
                //stack = ex.StackTrace
            });
        }

        public static string ToJson(this ValidationException ex)
        {
            return JsonConvert.SerializeObject(new
            {
                name = ex.Message,
                message = string.Join("<br/>", ex.Errors),
                //stack = ex.StackTrace
            });
        }

       
    }
}
