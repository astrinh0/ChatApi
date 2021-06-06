﻿namespace ChatApi.Infrastructure.Data.DTO
{
    public class MessageForJson
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
    }
}
