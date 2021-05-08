using ChatApi.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Models
{
    public class Group
    {
        public int Id { get; set; }
        public EnumTypeGroup Type { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ChangedAt { get; set; }

        public EnumFlag Active { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<GroupMessage> GroupMessages { get; set; }


    }
}
