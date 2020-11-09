using Domain.XUnitTest;
using FluentValidation.TestHelper;
using MonitoringSQLServer.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Repository.XUnitTest
{
    public class UserValidateTest : BaseTest
    {
        [Fact]
        [Obsolete]
        public void AnonymousUser()
        {
            var validator = new UserValidator();

            var model = new User { FirstName = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.FirstName);
        }

        [Fact]
        [Obsolete]
        public void RequiredField()
        {
            var validator = new UserValidator();

            var model = new User
            {
                FirstName = "  ",
                LastName = "",
                Email = "UserEmail@gmail.com"
            };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(f => f.FirstName)
                .WithErrorMessage("First Name error: required field");
            result.ShouldHaveValidationErrorFor(l => l.LastName)
                .WithErrorMessage("Last Name error: required field");
            result.ShouldNotHaveValidationErrorFor(e => e.Email);
        }

        [Fact]
        [Obsolete]
        public void NumbersInsteadOfLetters()
        {
            var validator = new UserValidator();

            var model = new User { 
                FirstName = "123",
                LastName = "456",
                Email = "UserEmail@gmail.com"
            };
            var result = validator.TestValidate(model);
            
            result.ShouldHaveValidationErrorFor(f => f.FirstName)
                .WithErrorMessage("First Name error: the First Name field must be letters");
            result.ShouldHaveValidationErrorFor(l => l.LastName)
                .WithErrorMessage("Last Name error: the Last Name field must be letters");
            result.ShouldNotHaveValidationErrorFor(e => e.Email);
        }

        [Fact]
        [Obsolete]
        public void InvalidEmail()
        {
            var validator = new UserValidator();

            var model = new User
            {
                FirstName = "Smit",
                LastName = "Abrams",
                Email = "UserEmail@gmaicom"
            };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(f => f.FirstName);
            result.ShouldNotHaveValidationErrorFor(l => l.LastName);
            result.ShouldHaveValidationErrorFor(e => e.Email)
                .WithErrorMessage("Email error: invalid email");
        }

        [Fact]
        [Obsolete]
        public void TooShortName()
        {
            var validator = new UserValidator();

            var model = new User
            {
                FirstName = "UserNameUserNameUserNameUserNameUserNameUserNameUserName",
                LastName = "UserNameUserNameUserNameUserNameUserNameUserNameUserName",
                Email = "UserEmail@gmail.com"
            };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(f => f.FirstName)
                .WithErrorMessage("First Name error: maximum length of 50 char allowed");
            result.ShouldHaveValidationErrorFor(l => l.LastName)
                .WithErrorMessage("Last Name error: maximum length of 50 char allowed");
            result.ShouldNotHaveValidationErrorFor(e => e.Email);
        }

        [Fact]
        [Obsolete]
        public void ToolongMame()
        {
            var validator = new UserValidator();

            var model = new User
            {
                FirstName = "A",
                LastName = "B",
                Email = "UserEmail@gmail.com"
            };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(f => f.FirstName)
                .WithErrorMessage("First Name error: minimum length of 2 char allowed");
            result.ShouldHaveValidationErrorFor(l => l.LastName)
                .WithErrorMessage("Last Name error: minimum length of 2 char allowed");
            result.ShouldNotHaveValidationErrorFor(e => e.Email);
        }
    }
}
