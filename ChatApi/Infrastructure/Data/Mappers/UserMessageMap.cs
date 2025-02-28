﻿using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApi.Infrastructure.Mappers
{
    public class UserMessageMap : IEntityTypeConfiguration<UserMessage>
    {
        public void Configure(EntityTypeBuilder<UserMessage> builder)
        {

            builder.ToTable("User_Message");

            builder
                .HasKey(um => new { um.MessageId, um.ReceiverId });

            builder.Property(u => u.MessageId)
                .HasColumnName("um_ms_id");


            builder.Property(u => u.ReceiverId)
                .HasColumnName("um_receiver_id");

            builder.Property(u => u.CreatedAt)
                .HasColumnName("um_createdat");


            builder
                 .HasOne(m => m.Message)
                 .WithMany(um => um.UserMessages)
                 .HasForeignKey(um => um.MessageId);

            builder
                .HasOne(u => u.Receiver)
                .WithMany(um => um.ReceiveMessages)
                .HasForeignKey(um => um.ReceiverId);
        }
    }
}
