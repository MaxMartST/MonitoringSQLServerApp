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
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
            Assert.Equal(GetTestUsers().FirstOrDefault(), result);

        }

        private IQueryable<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User { Id=1, Name="Tom"},
                new User { Id=2, Name="Alice"},
                new User { Id=3, Name="Sam"},
                new User { Id=4, Name="Kate"}
            };
            var res = (IQueryable<User>)users;
            return (res.AsNoTracking());
        }
    }
}
