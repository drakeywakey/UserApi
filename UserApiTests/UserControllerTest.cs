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

            var list = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Doug",
                    LastName = "Dockson",
                    Address = "Murray",
                    Age = 39,
                    ImageSrc = "src",
                    Interests = "So much interest"
                },

                new User
                {
                    Id = 2,
                    FirstName = "Carl",
                    LastName = "Boon",
                    Address = "Massachusetts",
                    Age = 26,
                    ImageSrc = "src",
                    Interests = "Sports"
                }
            };

            _service.Setup(service => service.GetAllUsers()).Returns(list);

            _controller = new UserController(_service.Object);
        }

        [Fact]
        public void GetAll_ReturnsOk()
        {
            var result = _controller.GetAll();
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAll_ReturnsAllUsers()
        {
            var result = _controller.GetAll().Result as OkObjectResult;
            var items = Assert.IsType<List<User>>(result.Value);
            Assert.Equal(2, items.Count);  
        }
    }
}