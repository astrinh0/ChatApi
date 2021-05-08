using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Mappers
{
    public class UserMessageMap : IEntityTypeConfiguration<UserMessage>
    {
        public void Configure(EntityTypeBuilder<UserMessage> builder)
        {
            builder
                .HasKey(um => new { um.UserId, um.MessageId });

            builder
                 .HasOne(u => u.User)
                 .WithMany(um => um.UserMessages)
                 .HasForeignKey(um => um.UserId);

            builder
                 .HasOne(m => m.Message)
                 .WithMany(um => um.UserMessages)
                 .HasForeignKey(um => um.MessageId);
        }
    }
}
