using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : Controller
    {

        private readonly IGroupService _groupService;


        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        /// <summary>
        /// Get all groups and channels
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get all Groups/Channels", null, Tags = new[] { "3. Groups/Channels" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<Group>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet]
        [Route("/GetAllGroups")]
        public ActionResult<Group> GetGroupsAndChannels()
        {
            try
            {
                var groups =  _groupService.GetGroups();
                return Ok(groups);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }

        }

        /// <summary>
        /// Create a group or channel
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [SwaggerOperation("Create a group/channel", null, Tags = new[] { "3. Groups/Channels" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/AddGroup")]
        public async Task<string> AddGroupOrChannel(EnumTypeGroup type, string name)
        {
            try
            {
                var aux = _groupService.AddGroupOrChannel(type, User.Identity.Name, name);
                if (aux != null) return ("Group/Channel created!");
                else return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        /// <summary>
        /// Add a user to a group
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userToAdd"></param>
        /// <returns></returns>
        [SwaggerOperation("Add user to group", null, Tags = new[] { "3. Groups/Channels" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/AddUserToGroup")]
        public async Task<string> AddUserToGroup(string name, string userToAdd)
        {
            try
            {
               var aux = _groupService.AddUserToGroup(name, User.Identity.Name, userToAdd);
                if (aux == true) return ($"User added to group {name}");
                else return ($"{User.Identity.Name} isnt the owner!");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }


        /// <summary>
        /// Subscribe to a channel
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [SwaggerOperation("Subscribe to a channel", null, Tags = new[] { "3. Groups/Channels" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/SubscribeToChannel")]
        public async Task<string> SubscribeToChannel(string name)
        {
            try
            {
                _groupService.SubscribeToChannel(User.Identity.Name, name);
                return ($"Subscribed to {name} channel!");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }


        /// <summary>
        /// Unsubscribe to a channel
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [SwaggerOperation("Unsubscribe to a channel", null, Tags = new[] { "3. Groups/Channels" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPut]
        [Route("/UnsubscribeToChannel")]
        public async Task<string> UnsubscribeToChannel(string name)
        {
            try
            {
                _groupService.UnsubscribeToChannel(User.Identity.Name, name);
                return ($"Unsubscribed to {name} channel!");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        /// <summary>
        /// Remove a user from a Group
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userToRemove"></param>
        /// <returns></returns>
        [SwaggerOperation("Remove user from group", null, Tags = new[] { "3. Groups/Channels" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/RemoveUserFromGroup")]
        public async Task<string> RemoveUserFromGroup(string name, string userToRemove)
        {
            try
            {
                var aux = _groupService.RemoveUserToGroup(name, User.Identity.Name, userToRemove);
                if (aux == true) return ($"User removed from the group {name}");
                else return ($"{userToRemove} doesnt belong to {name}");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        /// <summary>
        /// Delete a group or channel
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        [SwaggerOperation("Delete group", null, Tags = new[] { "3. Groups/Channels" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPut]
        [Route("/RemoveGroupOrChannel")]
        public async Task<string> RemoveGroupOrChannel(string groupName)
        {
            try
            {
                var aux = _groupService.RemoveGroupOrChannel(groupName, User.Identity.Name);
                if (aux == true) return ("Group/Channel deleted!");
                else return "Group/Channel doesnt exist!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }



    }
}
