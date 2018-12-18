using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using UserApi.Infrastructure;
using UserApi.Interfaces;
using UserApi.Models;
using Xunit;

namespace UserApiTests
{
    public class UserRepositoryTest
    {
        IUserRepository _repository;
        Mock<UserContext> _context;

        public UserRepositoryTest()
        {
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
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(list.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(list.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());

            _context = new Mock<UserContext>();
            _context.Setup(c => c.Users).Returns(mockSet.Object);

            _repository = new UserRepository(_context.Object);
        }

        [Fact]
        public void GetAll_WithSearchString_FindsMatchingUsers()
        {
            var result = _repository.GetAll("D");
            Assert.Contains(result, user => user.FirstName.Equals("Doug"));
        }

        [Fact]
        public void GetAll_WithSearchString_IsNotCaseSensitive()
        {
            var result = _repository.GetAll("c");
            Assert.Equal(2, result.Count());
            Assert.Contains(result, user => user.FirstName.Equals("Carl"));
        }
    }
}
