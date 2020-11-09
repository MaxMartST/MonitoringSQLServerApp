using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitoringSQLServer.Domain
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(i => i.Id)
                .NotNull();

            RuleFor(i => i.FirstName)
                .NotNull()
                .Must(c => c.All(Char.IsLetter))
                    .WithMessage("{PropertyName} error: поле {PropertyName} должно состоять из букв")
                .MinimumLength(2)
                    .WithMessage("{PropertyName} error: minimum length of {MinLength} char allowed")
                .MaximumLength(50)
                    .WithMessage("{PropertyName} error: maximum length of {MaxLength} char allowed");

            RuleFor(i => i.LastName)
                .NotNull()
                .Must(c => c.All(Char.IsLetter))
                    .WithMessage("{PropertyName} error: поле {PropertyName} должно состоять из букв")
                .MinimumLength(2)
                    .WithMessage("{PropertyName} error: minimum length of {MinLength} char allowed")
                .MaximumLength(50)
                    .WithMessage("{PropertyName} error: maximum length of {MaxLength} char allowed");

            RuleFor(i => i.Email)
                .EmailAddress();
        }
    }
}
