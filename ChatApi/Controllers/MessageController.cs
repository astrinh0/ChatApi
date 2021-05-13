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
        public async Task<ActionResult<Message>> GetUsers()
        {
            var messages = await _messageService.GetMessages();
            return Ok(messages);
        }

        [HttpPost]
        [Route("/SendMessage")]
        public ActionResult AddMessage(Message message)
        {
            _messageService.AddMessage(message);
            return Ok();
        }

        [HttpPut]
        [Route("/DeleteMessage")]
        public ActionResult RemoveMessage(int id)
        {
            _messageService.RemoveMessage(id);
            return Ok();
        }
    }


}

