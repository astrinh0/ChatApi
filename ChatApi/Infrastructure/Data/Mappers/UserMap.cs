using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Mappers
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("us_id");

            builder.Property(u => u.Name)
                .HasColumnName("us_name");

            builder.Property(u => u.Email)
                .HasColumnName("us_email");

            builder.Property(u => u.CreatedAt)
                .HasColumnName("us_createdat");

            builder.Property(u => u.ChangedAt)
             .HasColumnName("us_changedat");

            builder.Property(u => u.Active)
                .HasColumnName("us_active")
                .HasConversion(u => u.ToString(), u => (EnumFlag)Enum.Parse(typeof(EnumFlag), u));


            builder
                .HasMany(p => p.SendMessages)
                .WithOne(um => um.Sender)
                .HasForeignKey(um => um.SenderId);

            builder
               .HasMany(p => p.ReceiveMessages)
               .WithOne(um => um.Receiver)
               .HasForeignKey(um => um.ReceiverId);



        }
    }
}
