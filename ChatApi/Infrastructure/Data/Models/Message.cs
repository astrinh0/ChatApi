using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApi.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual User Sender { get; set; }

        public virtual ICollection<GroupMessage> GroupMessage { get; set; }

        public virtual ICollection<UserMessage> UserMessages { get; set; }


    }
}