using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Repos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository, IGroupRepository groupRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }


        public Message SendMessageToUser(string sender, string receiver, string message)
        {
            var senderUser = _userRepository.FindUserByUsername(sender);
            var receiverUser = _userRepository.FindUserByUsername(receiver);

            if (senderUser != null && receiverUser != null)
            {
                var aux = _messageRepository.SendMessageToUser(senderUser.Id, receiverUser.Id, message);
                return aux;
            }
            else
            {
                return null;
            }

        }

        public Message SendMessageToGroup(string sender, int groupId, string message)
        {
            var senderUser = _userRepository.FindUserByUsername(sender);
            var group = _groupRepository.GetGroup(groupId);

            if (senderUser != null && group != null)
            {
                if (_groupRepository.CheckIfUserBelongsToGroup(senderUser.Id, group.Id) == true)
                {
                    var aux =_messageRepository.SendMessageToGroup(senderUser.Id, group.Id, message);
                    return aux;
                }
                
            }
                return null;
            

        }

        public bool RemoveMessage(int id)
        {
            if (_messageRepository.RemoveMessage(id) == true)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Message> GetSentMessages(string username)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var aux = _messageRepository.GetSendedMessagesbyId(user.Id);
                return aux;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Message> GetReceivedMessages(string username)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var aux = _messageRepository.GetReceivedMessagesbyId(user.Id);
                return aux;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Message> GetReceivedMessagesUnread(string username)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var aux = _messageRepository.GetReceivedMessagesUnreadedbyId(user.Id);
                return aux;
            }
            else
            {
                return null;
            }
        }

        public int? GetNumberOfMessages(string username)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var aux = _messageRepository.GetReceivedMessagesbyId(user.Id);

                if (aux != null)
                {
                    return aux.Count();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}

