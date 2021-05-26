using ChatApi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Data.Mappers
{
    public class GroupUserMap : IEntityTypeConfiguration<GroupUser>
    {
        public void Configure(EntityTypeBuilder<GroupUser> builder)
        {
            builder.ToTable("Group_User");

            builder.Property(gu => gu.UserId)
                .HasColumnName("gu_us_id");

            builder.Property(u => u.GroupId)
                .HasColumnName("gu_gr_id");


            builder.Property(u => u.CreatedAt)
                .HasColumnName("gu_createdat");

            builder
                .HasKey(gu => new { gu.GroupId, gu.UserId });

            builder
                 .HasOne(gu => gu.Group)
                 .WithMany(g => g.GroupUsers)
                 .HasForeignKey(gu => gu.GroupId);

            builder
                 .HasOne(gu => gu.User)
                 .WithMany(u => u.GroupUsers)
                 .HasForeignKey(gu => gu.UserId);
        }
    }
}
