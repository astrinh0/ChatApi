using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("/GetAll")]
        public async Task<ActionResult<User>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("/register")]
        public ActionResult AddUser(User user)
        {
            _userService.AddUser(user);
            return Ok();
        }

        [HttpDelete]
        [Route("/remove")]
        public ActionResult RemoveUser(int id)
        {
            _userService.RemoveUser(id);
            return Ok();
        }
    }

}