using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
            try
            {
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }

            
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/AddUser")]
        public ActionResult AddUser(string name, string email, string username, string password)
        {
            try
            {
                _userService.AddUser(name, email, username, password);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }

        }

        [HttpPut]
        [Route("/RemoveUser")]
        public ActionResult RemoveUser(string? username)
        {
            try
            {
                _userService.RemoveUser(User.Identity.Name, username);
                return Ok();
            }
            catch (Exception ex) { return Json(ex); }
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [HttpPut]
        [Route("/ChangePassword")]
        public ActionResult ChangePassword(string password)
        {
            try
            {
                _userService.ChangePassword(User.Identity.Name, password);
                return Ok();
            }
            catch (Exception ex) { return Json(ex); }
           
        }
    }

}