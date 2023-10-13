using CQRSDemo.Framework.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator() 
        {
            RuleFor(c => c.Name)
                .MaximumLength(50)
                .WithMessage("Name is not more than 50 characters");

            RuleFor(c => c.Email)
                .EmailAddress();

            RuleFor(c => c.Phone)
                .Matches("^\\d{10}$")
                .WithMessage("Phone number must be 10 digits and characters not allow");
        }

    }
}
