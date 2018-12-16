using System;
using System.Collections.Generic;
using UserApi.Interfaces;
using UserApi.Models;

namespace UserApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public IEnumerable<User> SearchUsers(string search)
        {
            return _repository.GetAll(search);
        }
    }
}
