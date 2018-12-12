using System;
using System.Collections.Generic;
using UserApi.Models;

namespace UserApi.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
    }
}
