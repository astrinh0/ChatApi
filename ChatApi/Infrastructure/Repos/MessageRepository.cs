using ChatApi.Infrastructure.DB;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
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

        public Message SendMessageToUser(int senderId, int receiverId, string message)
        {
            Message aux = new Message();

            aux.Active = Models.Enums.EnumFlag.Y;
            aux.ActualMessage = message;
            aux.ChangedAt = null;
            aux.CreatedAt = DateTime.UtcNow;
            aux.GroupMessage = null;
            aux.SenderId = senderId;

            _context.Messages.Add(aux);
            _context.SaveChanges();

            UserMessage userMessage = new UserMessage();

            userMessage.CreatedAt = DateTime.UtcNow;
            userMessage.ReceiverId = receiverId;
            userMessage.MessageId = aux.Id;

            _context.UserMessages.Add(userMessage);
            _context.SaveChanges();


            return aux;

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

        public IEnumerable<Message> GetSendedMessagesbyId(int userId)
        {
           

        }

        public IEnumerable<Message> GetReceivedMessagesbyId(int userId)
        {
            var listOfUserMessage = _context.UserMessages.Where(um => um.ReceiverId == userId).ToList();

            var aux = new List<Message>();

            foreach (var message in listOfUserMessage)
            {
                var msg = _context.Messages.FirstOrDefault(c => c.Id == message.MessageId);
                aux.Add(msg);
            }

            return aux;

        }
    }
}

