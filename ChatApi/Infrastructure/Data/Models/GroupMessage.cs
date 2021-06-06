using System;

namespace ChatApi.Infrastructure.Models
{
    public class GroupMessage
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
