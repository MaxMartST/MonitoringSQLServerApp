using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringSQLServer.Domain;
using MonitoringSQLServerApp.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.XUnitTest
{
    public class UsersControllerTest
    {
        [Fact]
        public void GetReturnsAViewResultWithAListOfUsers()
        {
            // Arrange
            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup(repo => repo.User.FindAll()).Returns(GetTestUsers());
            var controller = new UsersController(mock.Object);
            // Act
            var result = controller.Get();
            // Assert
            var resultTyp = Assert.IsType<ActionResult<User>>(result);
            var mocRes = GetTestUsers();
            Assert.Equal(new ObjectResult(mocRes), result);

        }

        private IEnumerable<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User { Name="Tom"},
                new User { Name="Alice"},
                new User { Name="Sam"},
                new User { Name="Kate"}
            };

            return users;
        }
    }
}
