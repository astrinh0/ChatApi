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

        Message AddMessage(Message message);

        bool RemoveMessage(int id);

    }
}
