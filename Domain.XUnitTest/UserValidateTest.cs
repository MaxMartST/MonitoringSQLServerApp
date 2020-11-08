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

            var model = new User { FirstName = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(u => u.FirstName);
        }
    }
}
