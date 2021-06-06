using System;
using System.Collections.Generic;
using ChatApi.Infrastructure.Models.Enums;

namespace ChatApi.Infrastructure.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string ActualMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ChangedAt { get; set; }
        public EnumFlag Active { get; set; }
        public EnumFlag Readed { get; set; }
        public virtual User Sender { get; set; }

        public virtual ICollection<GroupMessage> GroupMessage { get; set; }

        public virtual ICollection<UserMessage> UserMessages { get; set; }


    }
}