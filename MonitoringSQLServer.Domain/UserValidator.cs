using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(i => i.Id)
                .NotNull();
            RuleFor(i => i.LastName)
                .NotNull()
                .MinimumLength(2)
                    .WithMessage("Minimum length of 2 char allowed")
                .MaximumLength(50)
                    .WithMessage("Maximum length of 50 char allowed");
            RuleFor(i => i.FirstName)
                .NotNull()
                .MinimumLength(2)
                    .WithMessage("Minimum length of 2 char allowed")
                .MaximumLength(50)
                    .WithMessage("Maximum length of 50 char allowed");
            RuleFor(i => i.Email)
                .EmailAddress();
        }
    }
}
