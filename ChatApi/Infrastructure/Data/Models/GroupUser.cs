using ChatApi.Infrastructure.Models;
using System;

namespace ChatApi.Infrastructure.Data.Models
{
    public class GroupUser
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
