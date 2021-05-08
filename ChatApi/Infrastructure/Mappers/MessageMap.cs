using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Mappers
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ms_id");

            builder.Property(x => x.ActualMessage)
                .HasColumnName("ms_message");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("ms_createdat");

            builder.Property(x => x.CreatedAt)
             .HasColumnName("ms_changedat");

            builder
               .HasMany(p => p.UserMessages)
               .WithOne(p => p.Message)
               .HasForeignKey(p => p.MessageId);

            builder
               .HasMany(p => p.GroupMessage)
               .WithOne(p => p.Message)
               .HasForeignKey(p => p.MessageId);


        }
    }
}
