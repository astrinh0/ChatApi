using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApi.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChatApi.Infrastructure.Models
{
    public class Message
    {
        [Key]
        [Column("ms_name")] public int Id { get; set; }
        [ForeignKey("User")] [Column("ms_sender_id")] public int UserSender { get; set; }
        [ForeignKey("User")] [Column("ms_receiver_id")] public int UserReceiver { get; set; }
        [Column("ms_message")] public string ActualMessage { get; set; } 
        [Column("ms_status")] public EnumStatusMessage Status { get; set; }
        [Column("ms_createdat")] public DateTime CreatedAt { get; set; }
    }
}