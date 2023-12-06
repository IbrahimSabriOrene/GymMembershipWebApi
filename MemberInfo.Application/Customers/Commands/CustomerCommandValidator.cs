using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MemberInfo.Application.Customers.Commands
{
    public class CustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CustomerCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\d{10}$");
        }
        
    }
}