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
            var user = usersController.Get(1);
            //var result = user.FirstOrDefault();

            // Assert
            Assert.Equal(null, user.Value.Name); 
        }
    }
}
