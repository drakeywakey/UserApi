using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using UserApi.Infrastructure;
using UserApi.Interfaces;
using UserApi.Models;
using UserApi.Services;
using Xunit;

namespace UserApiTests
{
    public class UserServiceTest
    {
        IUserService _service;
        Mock<IUserRepository> _repository;

        public UserServiceTest()
        {
            _repository = new Mock<IUserRepository>();

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
                    FirstName = "Sylvia",
                    LastName = "Plat",
                    Address = "Germany",
                    Age = 44,
                    ImageSrc = "src",
                    Interests = "Poetry"
                },

                new User
                {
                    Id = 3,
                    FirstName = "Walt",
                    LastName = "White",
                    Address = "New Mexico",
                    Age = 56,
                    ImageSrc = "src",
                    Interests = "Meth"
                },

                new User
                {
                    Id = 4,
                    FirstName = "Carl",
                    LastName = "Boon",
                    Address = "Massachusetts",
                    Age = 26,
                    ImageSrc = "src",
                    Interests = "Sports"
                },

                new User
                {
                    Id = 5,
                    FirstName = "Penny",
                    LastName = "Shelstorp",
                    Address = "Canada",
                    Age = 19,
                    ImageSrc = "src",
                    Interests = "Pink"
                }
            };

            _repository.Setup(repo => repo.GetAll()).Returns(list);
            _repository.Setup(repo => repo.GetAll("D")).Returns(
                list.Where(user => user.FirstName.Equals("Doug")));

            _service = new UserService(_repository.Object);
        }

        [Fact]
        public void GetAll_ReturnsAllUsers()
        {
            Assert.Equal(5, _service.GetAllUsers().Count());
        }

        [Fact]
        public void Search_FindsMatchingUsers()
        {
            var result = _service.SearchUsers("D");
            Assert.True(result.Any(user => user.FirstName.Equals("Doug")));
        }
    }
}
