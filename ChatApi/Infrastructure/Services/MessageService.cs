using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public Task<IEnumerable<Message>> GetMessages()
        {
            var users = _messageRepository.GetAll();
            return users;
        }

        public Message SendMessageToUser(int senderId, int receiverId, string message)
        {
            if (_userRepository.UserExistsAndActive(senderId) && _userRepository.UserExistsAndActive(receiverId) == true)
            {
                var aux = _messageRepository.SendMessageToUser(senderId, receiverId, message);
                return aux;
            }
            else
            {
                return null;
            }

        }

        public bool RemoveMessage(int id)
        {
            if (_messageRepository.RemoveMessage(id) == true)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Message> GetSendedMessagesByUserId(int userId)
        {
            if (_userRepository.UserExistsAndActive(userId))
            {
                var aux = _messageRepository.GetSendedMessagesbyId(userId);
                return aux;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Message> GetReceivedMessagesByUserId(int userId)
        {
            if (_userRepository.UserExistsAndActive(userId))
            {
                var aux = _messageRepository.GetReceivedMessagesbyId(userId);
                return aux;
            }
            else
            {
                return null;
            }
        }
    }
}

