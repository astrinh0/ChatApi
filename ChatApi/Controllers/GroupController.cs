﻿using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
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

        [SwaggerOperation("Get all Groups", null, Tags = new[] { "3. Groups" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet]
        [Route("/GetAllGroups")]
        public async Task<ActionResult<Group>> GetGroups()
        {
            try
            {
                var groups = await _groupService.GetGroups();
                return Ok(groups);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
            
        }


        [SwaggerOperation("Create a group", null, Tags = new[] { "3. Groups" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/AddGroup")]
        public ActionResult AddGroup(EnumTypeGroup type, string name)
        {
            try
            {
                _groupService.AddGroup(type, User.Identity.Name, name);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
          
        }


        [SwaggerOperation("Add user to group", null, Tags = new[] { "3. Groups" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/AddUserToGroup")]
        public ActionResult AddUserToGroup(string name, string userToAdd)
        {
            try
            {
                _groupService.AddUserToGroup(name, User.Identity.Name, userToAdd);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }

        }


        [SwaggerOperation("Remove user from group", null, Tags = new[] { "3. Groups" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/RemoveUserFromGroup")]
        public ActionResult RemoveUserFromGroup(string name, string userToAdd)
        {
            try
            {
                _groupService.RemoveUserToGroup(name, User.Identity.Name, userToAdd);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }

        }


        [SwaggerOperation("Delete group", null, Tags = new[] { "3. Groups" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPut]
        [Route("/RemoveGroup")]
        public ActionResult RemoveGroup(int id)
        {
            try
            {
                _groupService.RemoveGroup(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }

        }
    }
}
