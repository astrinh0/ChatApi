using ChatApi.Infrastructure.Data.DTO;
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

        public Message SendMessageToGroup(string sender, string groupName, string message)
        {
            var senderUser = _userRepository.FindUserByUsername(sender);
            var group = _groupRepository.GetGroupByName(groupName);

            if (senderUser != null && group != null)
            {
                if (_groupRepository.CheckIfUserBelongsToGroupOrChannel(senderUser.Id, group.Id) == true || group.OwnerId == senderUser.Id)
                {
                    var aux =_messageRepository.SendMessageToGroup(senderUser.Id, group.Id, message);
                    return aux;
                }
                
            }
                return null;
            

        }

        public Message SendMessageToChannel(string sender, string channelName, string message)
        {
            var senderUser = _userRepository.FindUserByUsername(sender);
            var channel = _groupRepository.GetChannelByName(channelName);

            if (senderUser != null && channel != null)
            {
                if (senderUser.Id == channel.OwnerId)
                {
                    var aux = _messageRepository.SendMessageToChannel(senderUser.Id, channel.Id, message);
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

        public IEnumerable<MessageForJson> GetSentMessages(string username)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var aux = _messageRepository.GetSendedMessagesbyId(user.Id);
                var list = new List<MessageForJson>();
                foreach (var item in aux)
                {
                    var UserMessage = _messageRepository.GetReceiver(item.Id);
                    var receiver = _userRepository.UserName(UserMessage.ReceiverId);
                    var newItem = new MessageForJson
                    {
                        Id = item.Id,
                        Message = item.ActualMessage,
                        Sender = _userRepository.UserName(item.SenderId),
                        Receiver = receiver
                    };
                    list.Add(newItem);
                }

                return list;
                
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<MessageForJson> GetReceivedMessages(string username)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var aux = _messageRepository.GetReceivedMessagesbyId(user.Id);
                var list = new List<MessageForJson>();
                foreach (var item in aux)
                {
                    var newItem = new MessageForJson
                    {
                        Id = item.Id,
                        Message = item.ActualMessage,
                        Sender = _userRepository.UserName(item.SenderId),
                        Receiver = _userRepository.UserName(user.Id)
                    };
                    list.Add(newItem);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<MessageForJson> GetReceivedMessagesUnread(string username)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var aux = _messageRepository.GetReceivedMessagesUnreadedbyId(user.Id);
                var list = new List<MessageForJson>();
                foreach (var item in aux)
                {
                    var newItem = new MessageForJson
                    {
                        Id = item.Id,
                        Message = item.ActualMessage,
                        Sender = _userRepository.UserName(item.SenderId),
                        Receiver = _userRepository.UserName(user.Id)
                    };
                    list.Add(newItem);

                }

                return list;
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

        public async Task<int?> GetNumberOfMessagesUnread(string username)
        {
            var user = _userRepository.FindUserByUsername(username);

            if (user != null)
            {
                var aux = await _messageRepository.GetNumberOfMessagesUnread(user.Id);

                if (aux != null)
                {
                    return aux;
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

