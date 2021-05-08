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

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
                .HasColumnName("gr_id");


            builder.Property(x => x.CreatedAt)
                .HasColumnName("gr_createdat");

            builder.Property(x => x.CreatedAt)
             .HasColumnName("gr_changedat");

            builder.Property(x => x.Type)
                .HasColumnName("gr_type")
                .HasConversion(x => x.ToString(), x => (EnumTypeGroup)Enum.Parse(typeof(EnumTypeGroup), x));

            builder.Property(x => x.Active)
                .HasColumnName("gr_active")
                .HasConversion(x => x.ToString(), x => (EnumFlag)Enum.Parse(typeof(EnumFlag), x));

            builder
                .HasOne(p => p.Owner)
                .WithMany(b => b.Groups)
                .HasForeignKey(p => p.OwnerId);

            //REVIEW
            builder
                .HasMany(p => p.GroupMessages)
                .WithOne(p => p.Group)
                .HasForeignKey(p => p.MessageId);

           

         
            
        }
    }
}
