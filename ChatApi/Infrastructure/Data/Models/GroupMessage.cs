using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Models
{
    public class GroupMessage
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
