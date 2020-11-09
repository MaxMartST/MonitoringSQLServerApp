using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class UserValidator : AbstractValidator<User>
    {
        [Obsolete]
        public UserValidator()
        {
            RuleFor(i => i.Id)
                .NotNull();

            RuleFor(i => i.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                    .WithMessage("{PropertyName} error: required field")
                .Must(IsValidName)
                    .WithMessage("{PropertyName} error: the {PropertyName} field must be letters")
                .MinimumLength(2)
                    .WithMessage("{PropertyName} error: minimum length of {MinLength} char allowed")
                .MaximumLength(50)
                    .WithMessage("{PropertyName} error: maximum length of {MaxLength} char allowed");

            RuleFor(i => i.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                    .WithMessage("{PropertyName} error: required field")
                .Must(IsValidName)
                    .WithMessage("{PropertyName} error: the {PropertyName} field must be letters")
                .MinimumLength(2)
                    .WithMessage("{PropertyName} error: minimum length of {MinLength} char allowed")
                .MaximumLength(50)
                    .WithMessage("{PropertyName} error: maximum length of {MaxLength} char allowed");

            RuleFor(i => i.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                    .WithMessage("{PropertyName} error: required field")
                .MinimumLength(2)
                    .WithMessage("{PropertyName} error: minimum length of {MinLength} char allowed")
                .MaximumLength(50)
                    .WithMessage("{PropertyName} error: maximum length of {MaxLength} char allowed")
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                    .WithMessage("{PropertyName} error: invalid email");
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
