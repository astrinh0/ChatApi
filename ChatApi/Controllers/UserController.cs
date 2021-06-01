using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [SwaggerOperation("Return all the users", null, Tags = new[] { "1. Users" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<User>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
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

        [SwaggerOperation("Add a user", null, Tags = new[] { "1. Users" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
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


        [SwaggerOperation("Remove a user", null, Tags = new[] { "1. Users" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
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



        [SwaggerOperation("Autenticate a user", null, Tags = new[] { "1. Users" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }



        [SwaggerOperation("Change password", null, Tags = new[] { "1. Users" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
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