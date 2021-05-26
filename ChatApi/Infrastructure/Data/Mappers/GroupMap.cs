using ChatApi.Infrastructure.Models;
using ChatApi.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace ChatApi.Infrastructure.Mappers
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("gr_id");


            builder.Property(g => g.CreatedAt)
                .HasColumnName("gr_createdat");

            builder.Property(g => g.CreatedAt)
             .HasColumnName("gr_changedat");

            builder.Property(g => g.Type)
                .HasColumnName("gr_type")
                .HasConversion(g => g.ToString(), x => (EnumTypeGroup)Enum.Parse(typeof(EnumTypeGroup), x));

            builder.Property(g => g.Active)
                .HasColumnName("gr_active")
                .HasConversion(g => g.ToString(), x => (EnumFlag)Enum.Parse(typeof(EnumFlag), x));

            builder
                .HasOne(g => g.Owner)
                .WithMany(u => u.OwnerGroups)
                .HasForeignKey(g => g.OwnerId);

      
            builder
                .HasMany(p => p.GroupMessages)
                .WithOne(p => p.Group)
                .HasForeignKey(p => p.MessageId);

           

         
            
        }
    }
}
