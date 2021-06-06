using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ChatApi.Infrastructure.Data.Mappers
{
    public class FileMap : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("File");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("fl_id");

            builder.Property(f => f.OwnerId)
               .HasColumnName("fl_owner_id");

            builder.Property(f => f.Name)
               .HasColumnName("fl_name");

            builder.Property(f => f.CreatedAt)
                .HasColumnName("fl_createdat");

            builder.Property(f => f.ChangedAt)
             .HasColumnName("fl_changedat");

            builder.Property(f => f.ExpireAt)
             .HasColumnName("fl_endedat");

            builder.Property(g => g.Active)
               .HasColumnName("fl_active")
               .HasConversion(g => g.ToString(), x => (EnumFlag)Enum.Parse(typeof(EnumFlag), x));


            builder
                .HasOne(g => g.Owner)
                .WithMany(u => u.Files)
                .HasForeignKey(g => g.OwnerId);
        }
    }
}
