using System;
using System.Collections.Generic;
using System.Threading;
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

        public IEnumerable<User> SearchUsers(string search, int wait)
        {
            if (wait > 0)
            {
                Thread.Sleep(wait * 1000);
            }

            if (search == null)
            {
                return new List<User>();
            }

            if (search == "")
            {
                return _repository.GetAll();
            }

            return _repository.GetAll(search);
        }
    }
}
