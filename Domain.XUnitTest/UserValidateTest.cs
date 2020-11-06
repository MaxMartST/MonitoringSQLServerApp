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
        public void AnonymousUser()
        {
            var validator = new UserValidator();
            var model = new User { Name = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.Name);
        }

        [Fact]
        public void UserNamed()
        {
            var validator = new UserValidator();
            var model = new User { Name = "Jeremy" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(u => u.Name);
        }
    }
}
