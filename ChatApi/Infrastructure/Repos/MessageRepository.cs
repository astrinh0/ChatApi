using ChatApi.Infrastructure.DB;
using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            var users = await _context.Messages.ToListAsync();
            return users;
        }

        public Message AddMessage(Message message)
        {
            message.CreatedAt = DateTime.UtcNow;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public bool RemoveMessage(int id)
        {
            var message = _context.Messages.Find(id);

            if (message == null)
            {
                return false;
            }

            message.Active = Models.Enums.EnumFlag.N;
            _context.Messages.Update(message);
            _context.SaveChanges();
            return true;
        }
    }
}

