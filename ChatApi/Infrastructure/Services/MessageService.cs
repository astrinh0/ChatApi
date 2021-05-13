using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task<IEnumerable<Message>> GetMessages()
        {
            var users = _messageRepository.GetAll();
            return users;
        }

        public Message AddMessage(Message message)
        {
            _messageRepository.AddMessage(message);
            return message;
        }

        public bool RemoveMessage(int id)
        {
            if (_messageRepository.RemoveMessage(id) == true)
            {
                return true;
            }
            return false;
        }
    }
}

