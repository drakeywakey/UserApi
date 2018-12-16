using System;
using System.Collections.Generic;
using System.Linq;
using UserApi.Interfaces;
using UserApi.Models;

namespace UserApi.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;

            if (_context.Users.Find(1L) == null)
            {
                _context.Database.EnsureCreated();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
    }
}
