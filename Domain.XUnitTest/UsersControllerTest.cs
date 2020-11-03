using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Application;
using MonitoringSQLServer.Domain;
using MonitoringSQLServerApp.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.XUnitTest
{
    public class FindUserById : TestBase
    {
        [Fact]
        public void GetReturnsAViewResultWithAListOfUsers()
        {
            // Arrange
            var controller = new RepositoryWrapper(_context);
            // Act
            var user = controller.User.FindByCondition(x => x.Id == 1);
            var result = user.FirstOrDefault();
            // Assert
            Assert.Equal("Jerry", result.Name);
        }
    }
}
