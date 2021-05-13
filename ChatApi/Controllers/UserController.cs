using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("[controllers]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("/GetAllUsers")]
        public async Task<ActionResult<User>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("/AddUser")]
        public ActionResult AddUser(User user)
        {
            _userService.AddUser(user);
            return Ok();
        }

        [HttpPut]
        [Route("/RemoveUser")]
        public ActionResult RemoveUser(int id)
        {
            _userService.RemoveUser(id);
            return Ok();
        }
    }

}