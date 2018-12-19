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
        Mock<IUserService> _service;

        public UserControllerTest()
        {
            _service = new Mock<IUserService>();
            _controller = new UserController(_service.Object);
        }

        [Fact]
        public void GetAll_ReturnsOk()
        {
            var result = _controller.GetAll();
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Search_ReturnsOk()
        {
            var result = _controller.Search("abcd", 0);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}