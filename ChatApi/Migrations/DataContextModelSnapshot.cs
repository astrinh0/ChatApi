﻿// <auto-generated />
using System;
using ChatApi.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ChatApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ChatApi.Infrastructure.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ms_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ActualMessage")
                        .HasColumnType("text")
                        .HasColumnName("ms_message");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("ms_createdat");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("ms_status");

                    b.Property<int>("UserReceiver")
                        .HasColumnType("integer")
                        .HasColumnName("ms_receiver_id");

                    b.Property<int>("UserSender")
                        .HasColumnType("integer")
                        .HasColumnName("ms_sender_id");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatApi.Infrastructure.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("us_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Active")
                        .HasColumnType("integer")
                        .HasColumnName("us_active");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("us_email");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("us_name");

                    b.Property<string>("Nickname")
                        .HasColumnType("text")
                        .HasColumnName("us_nickname");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
