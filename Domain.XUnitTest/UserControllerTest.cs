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
    public class FindUserById : BaseTest
    {
        [Fact]
        public void GetReturnsAViewResultWithAListOfUsers()
        {
            // Arrange
            var repositoryWrapper = new RepositoryWrapper(_context);
            var usersController = new UsersController(repositoryWrapper);

            // Act
            var result = usersController.Get(1);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsAssignableFrom<User>(objectResult.Value);

            // Assert
            Assert.Equal("Jerry", user.Name); 
        }
    }
}
