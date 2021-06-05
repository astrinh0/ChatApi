using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;


        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [SwaggerOperation("Send message to user", null, Tags = new[] { "2. Messages" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(ActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/SendMessageToUser")]
        public async Task<string> SendMessageToUser(string receiverName, string message)
        {
            try
            {
                var aux = _messageService.SendMessageToUser(User.Identity.Name, receiverName, message);
                if (aux != null) return ($"Message: {message} sent to {receiverName}");
                else return ("User doesn't exist.");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        [SwaggerOperation("Send message to group", null, Tags = new[] { "2. Messages" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost]
        [Route("/SendMessageToGroup")]
        public async Task<string> SendMessageToGroup(string groupName, string message)
        {
            try
            {
                var aux = _messageService.SendMessageToGroup(User.Identity.Name, groupName, message);
                if (aux != null) return ($"Message: {message} sent to group {groupName}");
                else return ("Group doesn't exist or you dont belong to this group.");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        [SwaggerOperation("See messages sent", null, Tags = new[] { "2. Messages" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(IEnumerable<Message>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet]
        [Route("/SentMessages")]
        public ActionResult MessagesSentByUser()
        {
            try
            {
               var messages = _messageService.GetSentMessages(User.Identity.Name);
                
                if (messages == null)
                {
                    return NoContent();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }


        [SwaggerOperation("See message received", null, Tags = new[] { "2. Messages" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(IEnumerable<Message>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet]
        [Route("/ReceivedMessages")]
        public ActionResult MessagesReceivedByUserId()
        {
            try
            {
                var messages = _messageService.GetReceivedMessages(User.Identity.Name);

                if (messages.Count() == 0 || messages == null)
                {
                    return NoContent();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }


        [SwaggerOperation("See messages unreaded", null, Tags = new[] { "2. Messages" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(IEnumerable<Message>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet]
        [Route("/UnreadedMessages")]
        public ActionResult MessagesReceivedUnreadedByUserId()
        {
            try
            {
                var messages = _messageService.GetReceivedMessagesUnread(User.Identity.Name);

                if (messages.Count() == 0 || messages == null)
                {
                    return NoContent();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }


        [SwaggerOperation("Number of messages", null, Tags = new[] { "2. Messages" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(int))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet]
        [Route("/NumberOfMessages")]
        public ActionResult GetNumberOfMessages()
        {
            try
            {
                var messages = _messageService.GetNumberOfMessages(User.Identity.Name);

                if (messages == null)
                {
                    return NoContent();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }


        [SwaggerOperation("Delete a message", null, Tags = new[] { "2. Messages" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPut]
        [Route("/DeleteMessage")]
        public async Task<string> RemoveMessage(int id)
        {
            try
            {
                _messageService.RemoveMessage(id);
                return ("Message deleted!");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           
        }
    }


}

