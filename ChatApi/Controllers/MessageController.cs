using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;


        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet]
        [Route("/GetAllMessages")]
        public async Task<ActionResult<Message>> GetAllMessages()
        {
            try
            {
                var messages = await _messageService.GetMessages();

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

        [HttpPost]
        [Route("/SendMessageToUser")]
        public ActionResult SendMessageToUser(string receiverName, string message)
        {
            try
            {
                _messageService.SendMessageToUser(User.Identity.Name, receiverName, message);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }

        [HttpPost]
        [Route("/SendMessageToGroup")]
        public ActionResult SendMessageToGroup(int groupId, string message)
        {
            try
            {
                _messageService.SendMessageToGroup(User.Identity.Name, groupId, message);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }

        [HttpGet]
        [Route("/AllMessagesSendByUserId")]
        public ActionResult MessagesSendByUserId(int userId)
        {
            try
            {
               var messages = _messageService.GetSendedMessagesByUserId(userId);
                
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

        [HttpGet]
        [Route("/AllMessagesReceiverByUserId")]
        public ActionResult MessagesReceivedByUserId(int userId)
        {
            try
            {
                var messages = _messageService.GetReceivedMessagesByUserId(userId);

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


        [HttpPut]
        [Route("/DeleteMessage")]
        public ActionResult RemoveMessage(int id)
        {
            try
            {
                _messageService.RemoveMessage(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
           
        }
    }


}

