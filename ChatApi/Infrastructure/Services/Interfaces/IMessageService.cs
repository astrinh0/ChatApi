using ChatApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessages();

        Message SendMessageToUser(string sender, string receiver, string message);

        bool RemoveMessage(int id);

        IEnumerable<Message> GetSendedMessagesByUserId(int userId);

        IEnumerable<Message> GetReceivedMessagesByUserId(int userId);

        Message SendMessageToGroup(string sender, int groupId, string message);
    }
}
