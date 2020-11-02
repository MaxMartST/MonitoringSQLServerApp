using Microsoft.AspNetCore.Mvc;
using MonitoringSQLServerApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace App.XUnitTest
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            // Arrange - выполняет начальную инициализацию контекста тестов
            HomeController controller = new HomeController();

            // Act
            // Так как метод Index контроллера возвращает объект ActionResult, то его еще надо привести к объекту ViewResult.
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.Equal("Hello world!", result?.ViewData["Message"]);
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewNameEqualIndex()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.Equal("Index", result?.ViewName);
        }
    }
}
