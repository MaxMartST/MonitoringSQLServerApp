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
    public class UserControllerTest : BaseTest
    {
        [Fact]
        public void GetUserViaId()
        {
            // Arrange
            var repositoryWrapper = new RepositoryWrapper(_context);
            var usersController = new UsersController(repositoryWrapper);
            var date = new DateTime(2020, 11, 09);

            // Act
            var result = usersController.Get(1);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsAssignableFrom<User>(objectResult.Value);

            // Assert
            Assert.Equal("Jerry", user.FirstName);
            Assert.Equal("First", user.LastName);
            Assert.Equal("Jerry-First@gmail.com", user.Email);
            Assert.Equal(date, user.RegDate);
        }

        [Fact]
        public void GetCustomerReturnsNotFoundGivenInvalidId()
        {
            // Arrange
            var repositoryWrapper = new RepositoryWrapper(_context);
            var usersController = new UsersController(repositoryWrapper);

            // Act
            var result = usersController.Get(99);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void AddNewUser()
        {
            // Arrange
            var repositoryWrapper = new RepositoryWrapper(_context);
            var usersController = new UsersController(repositoryWrapper);
            DateTime date = new DateTime();
            var newUser = new User()
            {
                FirstName = "Abel",
                LastName = "Kamf",
                Email = "Abel-Kamf@.com"
            };

            // Act
            var result = usersController.Post(newUser);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsAssignableFrom<User>(objectResult.Value);

            // Assert
            Assert.Equal("Abel", user.FirstName);
            Assert.Equal("Kamf", user.LastName);
            Assert.Equal("Abel-Kamf@.com", user.Email); 
            Assert.NotEqual(date, user.RegDate);
        }

        [Fact]
        public void UpdateNewUsername()
        {
            // Arrange
            var repositoryWrapper = new RepositoryWrapper(_context);
            var usersController = new UsersController(repositoryWrapper);
            var updatedUser = new User()
            {
                Id = 5,
                FirstName = "Max",
                LastName = "Mart",
                Email = "Max-Mart@gmail.com",
            };
            var oldResult = usersController.Get(5);

            // Act
            var result = usersController.Put(updatedUser);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsAssignableFrom<User>(objectResult.Value);

            // Assert
            Assert.Equal("Max", user.FirstName);
            Assert.Equal("Mart", user.LastName);
            Assert.Equal("Max-Mart@gmail.com", user.Email);
        }

        [Fact]
        public void DeleteUser()
        {
            // Arrange
            var repositoryWrapper = new RepositoryWrapper(_context);
            var usersController = new UsersController(repositoryWrapper);

            // Act
            var result = usersController.Delete(5);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsAssignableFrom<User>(objectResult.Value);
            var deleteUser = usersController.Get(5);

            // Assert
            Assert.Equal("Beth", user.FirstName);
            Assert.IsType<NotFoundResult>(deleteUser);
        }
    }
}
