using ChatApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAll();

        Message SendMessageToUser(int senderId, int receiverId, string message);

        bool RemoveMessage(int id);

        IEnumerable<Message> GetSendedMessagesbyId(int userId);

        IEnumerable<Message> GetReceivedMessagesbyId(int userId);

    }
}
