using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserApi.Interfaces;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetAllUsers().ToList();
        }
    }
}
