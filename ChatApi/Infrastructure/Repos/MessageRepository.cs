using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.DB;
using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
       

        public MessageRepository(DataContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
            
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
            var listOfSendedMessage = _context.Messages.Where(m => m.SenderId == userId).ToList();
            
            return listOfSendedMessage;

        }

        public UserMessage GetReceiver(int messageId)
        {
            return _context.UserMessages.FirstOrDefault(um => um.MessageId == messageId);
        }
            


        public IEnumerable<Message> GetReceivedMessagesbyId(int userId)
        {
            var listOfUserMessages = new List<UserMessage>();

            listOfUserMessages = _context.UserMessages.Where(um => um.ReceiverId == userId).ToList();

            var messages = new List<Message>();

            foreach (var message in listOfUserMessages)
            {
                var msg = _context.Messages.Where(m => m.Id == message.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.Y).ToList();
                if(msg != null && msg.Count > 0)
                {
                    foreach (var item in msg)
                    {
                        messages.Add(item);
                    }
                }
             
            }

            var listOfGroups = new List<GroupUser>();

            listOfGroups = _context.GroupUsers.Where(gu => gu.UserId == userId).ToList();

            foreach (var group in listOfGroups)
            {
                var groupsMsg = _context.GroupMessages.Where(gm => gm.GroupId == group.GroupId).ToList();
                if (groupsMsg != null && groupsMsg.Count > 0)
                {
                    foreach (var item in groupsMsg)
                    {
                        var msg = _context.Messages.Where(m => m.Id == item.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.Y).ToList();

                        if (msg != null && msg.Count > 0)
                        {
                            foreach (var mensagem in msg)
                            {
                                messages.Add(mensagem);
                            }
                        }
                    }
                }
            }

            var listOfGroupOwned = new List<Group>();

            listOfGroupOwned = _context.Groups.Where(gu => gu.OwnerId == userId).ToList();

            foreach (var group in listOfGroupOwned)
            {
                var groupsMsg = _context.GroupMessages.Where(gm => gm.GroupId == group.Id).ToList();
                if (groupsMsg != null && groupsMsg.Count() > 0)
                {
                    foreach (var item in groupsMsg)
                    {
                        var msg = _context.Messages.Where(m => m.Id == item.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.Y).ToList();

                        if (msg != null && msg.Count > 0)
                        {
                            foreach (var mensagem in msg)
                            {
                                mensagem.Readed = EnumFlag.Y;
                                _context.Messages.Update(mensagem);
                                _context.SaveChanges();
                                messages.Add(mensagem);
                            }
                        }
                    }
                }
            }


            return messages;

        }

        public IEnumerable<Message> GetReceivedMessagesUnreadedbyId(int userId)
        {
            var listOfUserMessages = new List<UserMessage>();

            listOfUserMessages = _context.UserMessages.Where(um => um.ReceiverId == userId).ToList();

            var messages = new List<Message>();

            foreach (var message in listOfUserMessages)
            {
                var msg = _context.Messages.Where(m => m.Id == message.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.N).ToList();
                if (msg != null && msg.Count() > 0)
                {
                    foreach (var item in msg)
                    {
                        item.Readed = EnumFlag.Y;
                        _context.Messages.Update(item);
                        _context.SaveChanges();
                        messages.Add(item);
                    }
                }

            }

            var listOfGroups = new List<GroupUser>();

            listOfGroups = _context.GroupUsers.Where(gu => gu.UserId == userId).ToList();

            foreach (var group in listOfGroups)
            {
                var groupsMsg = _context.GroupMessages.Where(gm => gm.GroupId == group.GroupId).ToList();
                if (groupsMsg != null && groupsMsg.Count > 0)
                {
                    foreach (var item in groupsMsg)
                    {
                        var msg = _context.Messages.Where(m => m.Id == item.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.N).ToList();

                        if (msg != null && msg.Count() > 0)
                        {
                            foreach (var mensagem in msg)
                            {
                                mensagem.Readed = EnumFlag.Y;
                                _context.Messages.Update(mensagem);
                                _context.SaveChanges();
                                messages.Add(mensagem);
                            }
                        }
                    }
                }
            }

            var listOfGroupOwned = new List<Group>();

            listOfGroupOwned = _context.Groups.Where(gu => gu.OwnerId == userId).ToList();

            foreach (var group in listOfGroupOwned)
            {
                var groupsMsg = _context.GroupMessages.Where(gm => gm.GroupId == group.Id).ToList();
                if (groupsMsg != null && groupsMsg.Count() > 0)
                {
                    foreach (var item in groupsMsg)
                    {
                        var msg = _context.Messages.Where(m => m.Id == item.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.N).ToList();

                        if (msg != null && msg.Count() > 0)
                        {
                            foreach (var mensagem in msg)
                            {
                                mensagem.Readed = EnumFlag.Y;
                                _context.Messages.Update(mensagem);
                                _context.SaveChanges();
                                messages.Add(mensagem);
                            }
                        }
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

        public Message SendMessageToChannel(int senderId, int channelId, string message)
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
            groupMessage.GroupId = channelId;
            groupMessage.MessageId = aux.Id;

            _context.GroupMessages.Add(groupMessage);
            _context.SaveChanges();


            return aux;

        }

        public int? GetNumberOfMessagesUnread(int userId)
        {
            
            



                var listOfUserMessages = new List<UserMessage>();

                listOfUserMessages = _context.UserMessages.Where(um => um.ReceiverId == userId).ToList();

                var messages = new List<Message>();

                foreach (var message in listOfUserMessages)
                {
                    var msg = _context.Messages.Where(m => m.Id == message.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.N).ToList();
                    if (msg != null && msg.Count() > 0)
                    {
                        foreach (var item in msg)
                        {
                            item.Readed = EnumFlag.Y;
                            _context.Messages.Update(item);
                            _context.SaveChanges();
                            messages.Add(item);
                        }
                    }

                }

                var listOfGroups = new List<GroupUser>();

                listOfGroups = _context.GroupUsers.Where(gu => gu.UserId == userId).ToList();

                foreach (var group in listOfGroups)
                {
                    var groupsMsg = _context.GroupMessages.Where(gm => gm.GroupId == group.GroupId).ToList();
                    if (groupsMsg != null && groupsMsg.Count > 0)
                    {
                        foreach (var item in groupsMsg)
                        {
                            var msg = _context.Messages.Where(m => m.Id == item.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.N).ToList();

                            if (msg != null && msg.Count() > 0)
                            {
                                foreach (var mensagem in msg)
                                {
                                    mensagem.Readed = EnumFlag.Y;
                                    _context.Messages.Update(mensagem);
                                    _context.SaveChanges();
                                    messages.Add(mensagem);
                                }
                            }
                        }
                    }
                }

                var listOfGroupOwned = new List<Group>();

                listOfGroupOwned = _context.Groups.Where(gu => gu.OwnerId == userId).ToList();

                foreach (var group in listOfGroupOwned)
                {
                    var groupsMsg = _context.GroupMessages.Where(gm => gm.GroupId == group.Id).ToList();
                    if (groupsMsg != null && groupsMsg.Count() > 0)
                    {
                        foreach (var item in groupsMsg)
                        {
                            var msg = _context.Messages.Where(m => m.Id == item.MessageId && m.Active == EnumFlag.Y && m.Readed == EnumFlag.N).ToList();

                            if (msg != null && msg.Count() > 0)
                            {
                                foreach (var mensagem in msg)
                                {
                                    mensagem.Readed = EnumFlag.Y;
                                    _context.Messages.Update(mensagem);
                                    _context.SaveChanges();
                                    messages.Add(mensagem);
                                }
                            }
                        }
                    }
                }

                return messages.Count;
           



        }


    }
}

