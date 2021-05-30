using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;


        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
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
        public ActionResult SendMessageToGroup(string groupName, string message)
        {
            try
            {
                _messageService.SendMessageToGroup(User.Identity.Name, groupName, message);
                return Ok();
            }
            catch (Exception ex)
            {

                return Json(ex);
            }
        }

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

        [HttpGet]
        [Route("/ReceivedMessages")]
        public ActionResult MessagesReceivedByUserId()
        {
            try
            {
                var messages = _messageService.GetReceivedMessages(User.Identity.Name);

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
        [Route("/UnreadedMessages")]
        public ActionResult MessagesReceivedUnreadedByUserId()
        {
            try
            {
                var messages = _messageService.GetReceivedMessagesUnread(User.Identity.Name);

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

