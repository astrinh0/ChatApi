using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatApi.Infrastructure.Models.Enums;

namespace ChatApi.Infrastructure.Models
{
    public class User
    {
        [Key] [Column("us_id")] public int Id { get; set; }

        [Column("us_name")] public string Name { get; set; }

        [Column("us_nickname")] public string Nickname { get; set; }

        [Column("us_email")] public string Email { get; set; }

        [Column("us_active")] public EnumFlag Active { get; set; }
        
    }
}