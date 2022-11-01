using _1CommonInfrastructure.Models;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;
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
            .WithMessage("Required field")
                .MaximumLength(500)
                    .WithMessage("Max allowed character less than 500")
            ;
            RuleFor(x => x.FamilyName)
                .NotEmpty()
                    .WithMessage("Required field")
                .MaximumLength(500)
                    .WithMessage("Max allowed character less than 500")
                ;            

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now)
                    .WithMessage("Date of birth must be in the past.")
                ;           
        }
    }
}
