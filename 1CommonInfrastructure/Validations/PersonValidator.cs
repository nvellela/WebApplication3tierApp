using _1CommonInfrastructure.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1CommonInfrastructure.Validations
{   
  public class PersonValidator : BaseValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(x => x.GivenName)
                .NotEmpty()
                // .WithMessage("This field cannot be empty")
                .WithMessage(ValidatorMessage.NotEmpty)

                .MaximumLength(400)
                    .WithMessage("Max Length allowed is (400)")
                ;

            RuleFor(x => x.FamilyName)
                .NotEmpty()
                    .WithMessage(ValidatorMessage.NotEmpty)
                .MaximumLength(400)
                    .WithMessage(ValidatorMessage.MaxLength(400))
                ;

            RuleFor(x => x.PreferredName)
                .MaximumLength(400)
                    .WithMessage(ValidatorMessage.MaxLength(400))
                ;

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now)
                    .WithMessage("Date of birth must be in the past.")
                ;
           
        }
    }
}
