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

        Message SendMessageToUser(int senderId, int receiverId, string message);

        bool RemoveMessage(int id);
    }
}
