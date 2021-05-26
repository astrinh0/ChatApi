using ChatApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Mappers
{
    public class GroupMessageMap : IEntityTypeConfiguration<GroupMessage>
    {
        public void Configure(EntityTypeBuilder<GroupMessage> builder)
        {

            builder.ToTable("Group_Message");

            builder.Property(u => u.MessageId)
                .HasColumnName("gm_ms_id");

            builder.Property(u => u.GroupId)
                .HasColumnName("gm_gr_id");


            builder.Property(u => u.CreatedAt)
                .HasColumnName("um_createdat");

            builder
                .HasKey(gm => new { gm.GroupId, gm.MessageId});

            builder
                 .HasOne(g => g.Group)
                 .WithMany(gm => gm.GroupMessages)
                 .HasForeignKey(gm => gm.GroupId);

            builder
                 .HasOne(m => m.Message)
                 .WithMany(gm => gm.GroupMessage)
                 .HasForeignKey(gm => gm.MessageId);



        }
    }
}
