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

      

        public Message SendMessageToUser(int senderId, int receiverId, string message)
        {
            Message aux = new Message();

            aux.Active = EnumFlag.Y;
            aux.ActualMessage = message;
            aux.ChangedAt = null;
            aux.CreatedAt = DateTime.UtcNow;
            aux.GroupMessage = null;
            aux.SenderId = senderId;
            aux.Readed = EnumFlag.N;

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

            message.Active = EnumFlag.N;
            _context.Messages.Update(message);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Message> GetSendedMessagesbyId(int userId)
        {
            var listOfSendedMessage = _context.Messages.Where(m => m.SenderId == userId);
            
            return listOfSendedMessage;

        }

        public IEnumerable<Message> GetReceivedMessagesbyId(int userId)
        {
            var listOfUserMessage = _context.UserMessages.Where(um => um.ReceiverId == userId).ToList();

            var messages = new List<Message>();

            foreach (var message in listOfUserMessage)
            {
                var msg = _context.Messages.FirstOrDefault(c => c.Id == message.MessageId && c.Active == EnumFlag.Y && c.Readed == EnumFlag.Y);
                messages.Add(msg);
            }


            var listOfGroupUsers = _context.GroupUsers.Where(gu => gu.UserId == userId).ToList();

            var groupMessages = new List<GroupMessage>();

            if (listOfGroupUsers != null)
            {
                foreach (var groupUser in listOfGroupUsers)
                {
                    var groupMsg = _context.GroupMessages.FirstOrDefault(gm => gm.GroupId == groupUser.GroupId);
                    groupMessages.Add(groupMsg);

                }

                if (groupMessages != null)
                {
                    foreach (var groupMessage in groupMessages)
                    {
                        var message = _context.Messages.FirstOrDefault(m => m.Id == groupMessage.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.Y);
                        messages.Add(message);
                    }
                }
            }
           
            return messages;

        }

        public IEnumerable<Message> GetReceivedMessagesUnreadedbyId(int userId)
        {
            var listOfUserMessage = _context.UserMessages.Where(um => um.ReceiverId == userId).ToList();

            var messages = new List<Message>();

            foreach (var message in listOfUserMessage)
            {
                var msg = _context.Messages.FirstOrDefault(c => c.Id == message.MessageId && c.Readed == EnumFlag.N && c.Active == EnumFlag.Y);
                msg.Readed = EnumFlag.Y;
                messages.Add(msg);
            }

            var listOfGroupUsers = _context.GroupUsers.Where(gu => gu.UserId == userId).ToList();

            var groupMessages = new List<GroupMessage>();

            if (listOfGroupUsers != null)
            {
                foreach (var groupUser in listOfGroupUsers)
                {
                    var groupMsg = _context.GroupMessages.FirstOrDefault(gm => gm.GroupId == groupUser.GroupId);
                    groupMessages.Add(groupMsg);

                }

                if (groupMessages != null)
                {
                    foreach (var groupMessage in groupMessages)
                    {
                        var message = _context.Messages.FirstOrDefault(m => m.Id == groupMessage.MessageId && m.Readed == EnumFlag.N && m.Active == EnumFlag.Y);
                        message.Readed = EnumFlag.Y;
                        messages.Add(message);
                    }
                }
            }

            return messages;

        }

        public Message SendMessageToGroup(int senderId, int groupId, string message)
        {
            Message aux = new Message();

            aux.Active = EnumFlag.Y;
            aux.ActualMessage = message;
            aux.ChangedAt = null;
            aux.CreatedAt = DateTime.UtcNow;
            aux.SenderId = senderId;
            aux.Readed = EnumFlag.N;

            _context.Messages.Add(aux);
            _context.SaveChanges();

            GroupMessage groupMessage = new GroupMessage();

            groupMessage.CreatedAt = DateTime.UtcNow;
            groupMessage.GroupId = groupId;
            groupMessage.MessageId = aux.Id;

            _context.GroupMessages.Add(groupMessage);
            _context.SaveChanges();


            return aux;

        }

        
    }
}

