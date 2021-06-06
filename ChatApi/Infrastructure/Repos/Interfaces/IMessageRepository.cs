using ChatApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public interface IMessageRepository
    {

        Message SendMessageToUser(int senderId, int receiverId, string message);

        Message SendMessageToGroup(int senderId, int groupId, string message);

        Message SendMessageToChannel(int senderId, int channelId, string message);

        bool RemoveMessage(int id);

        IEnumerable<Message> GetSendedMessagesbyId(int userId);

        IEnumerable<Message> GetReceivedMessagesbyId(int userId);

        IEnumerable<Message> GetReceivedMessagesUnreadedbyId(int userId);

        UserMessage GetReceiver(int messageId);

        int? GetNumberOfMessagesUnread(int userId);



    }
}
