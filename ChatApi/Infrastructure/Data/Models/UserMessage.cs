using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Models
{
    public class UserMessage
    {
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
