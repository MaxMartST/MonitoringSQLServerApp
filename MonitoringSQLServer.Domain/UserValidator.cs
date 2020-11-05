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
            RuleFor(i => i.Name)
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
