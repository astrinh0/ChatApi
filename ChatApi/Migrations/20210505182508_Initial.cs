using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ChatApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ms_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ms_sender_id = table.Column<int>(type: "integer", nullable: false),
                    ms_receiver_id = table.Column<int>(type: "integer", nullable: false),
                    ms_message = table.Column<string>(type: "text", nullable: true),
                    ms_status = table.Column<int>(type: "integer", nullable: false),
                    ms_createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ms_name);
					table.ForeignKey(
					name: "FK_ms_sender_id",
					column: x => x.ms_sender_id,
					principalTable: "Users",
					principalColumn: "us_id",
					 onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
					name: "FK_ms_receiver_id",
					column: x => x.ms_receiver_id,
					principalTable: "Users",
					principalColumn: "us_id",
					 onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    us_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    us_name = table.Column<string>(type: "text", nullable: true),
                    us_nickname = table.Column<string>(type: "text", nullable: true),
                    us_email = table.Column<string>(type: "text", nullable: true),
                    us_active = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.us_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
