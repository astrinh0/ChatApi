using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

            builder.Property(x => x.SenderId)
                .HasColumnName("ms_sender_id");

            builder.Property(x => x.ActualMessage)
                .HasColumnName("ms_message");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("ms_createdat");

            builder.Property(x => x.ChangedAt)
             .HasColumnName("ms_changedat");

            builder.Property(x => x.Active)
                .HasColumnName("ms_active")
                .HasConversion(x => x.ToString(), x => (EnumFlag)Enum.Parse(typeof(EnumFlag), x));

            builder.Property(x => x.Readed)
               .HasColumnName("ms_readed")
               .HasConversion(x => x.ToString(), x => (EnumFlag)Enum.Parse(typeof(EnumFlag), x));

            builder
               .HasMany(p => p.UserMessages)
               .WithOne(p => p.Message)
               .HasForeignKey(p => p.MessageId);

            builder
               .HasMany(p => p.GroupMessage)
               .WithOne(p => p.Message)
               .HasForeignKey(p => p.MessageId);

            builder
                .HasOne(p => p.Sender)
                .WithMany(b => b.SendMessages)
                .HasForeignKey(p => p.SenderId);


        }
    }
}
