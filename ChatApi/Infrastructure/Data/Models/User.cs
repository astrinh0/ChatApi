using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApi.Infrastructure.Models.Enums;

namespace ChatApi.Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ChangedAt { get; set; }
        public EnumFlag Active { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<UserMessage> SendMessages { get; set; }

        public virtual ICollection<UserMessage> ReceiveMessages { get; set; }

        public virtual ICollection<GroupMessage> SendMessageGroup { get; set; }





    }
}