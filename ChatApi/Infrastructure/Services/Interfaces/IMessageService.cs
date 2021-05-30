using ChatApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IMessageService
    {


        Message SendMessageToUser(string sender, string receiver, string message);

        bool RemoveMessage(int id);

        IEnumerable<Message> GetSentMessages(string username);

        IEnumerable<Message> GetReceivedMessages(string username);

        IEnumerable<Message> GetReceivedMessagesUnread(string username);

        Message SendMessageToGroup(string sender, string groupName, string message);

        int? GetNumberOfMessages(string username);

    }
}
