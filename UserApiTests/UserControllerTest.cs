using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UserApi.Controllers;
using UserApi.Interfaces;
using UserApi.Models;
using Xunit;

namespace UserApiTests
{
    public class UserControllerTest
    {
        UserController _controller;

        public UserControllerTest()
        {
            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.GetAllUsers()).Returns(new List<User>());
            _controller = new UserController(mockService.Object);
        }

        [Fact]
        public void GetAll_ReturnsOk()
        {
            var result = _controller.GetAll();
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}