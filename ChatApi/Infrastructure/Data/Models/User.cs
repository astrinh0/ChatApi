﻿using System;
using System.Collections.Generic;
using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.Models.Enums;

namespace ChatApi.Infrastructure.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


        public DateTime CreatedAt { get; set; }

        public DateTime? ChangedAt { get; set; }
        public EnumFlag Active { get; set; }


        public virtual ICollection<GroupUser> GroupUsers { get; set; }

        public virtual ICollection<Group> OwnerGroups { get; set; }

        public virtual ICollection<File> Files { get; set; }



        public virtual ICollection<Message> SendMessages { get; set; }

        public virtual ICollection<UserMessage> ReceiveMessages { get; set; }








    }
}