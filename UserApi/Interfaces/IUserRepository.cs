using System;
using System.Collections.Generic;
using UserApi.Models;

namespace UserApi.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAll(string search);
    }
}
