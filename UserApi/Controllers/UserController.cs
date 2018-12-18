﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet]
        [Route("search")]
        public ActionResult<List<User>> Search(string search, int wait)
        {
            if (wait > 0)
            {
                Thread.Sleep(wait * 1000);
            }
            return Ok(_userService.SearchUsers(search));
        }
    }
}
