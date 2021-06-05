using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Data.Models
{
    public class File
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }

        public string Name { get; set; }

        public EnumFlag Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ChangedAt { get; set; }

        public DateTime ExpireAt { get; set; }

        public virtual User Owner { get; set; }
    }
}
