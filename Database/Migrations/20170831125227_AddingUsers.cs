using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Database.Migrations
{
    public partial class AddingUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectlyAnswered",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IncorrectlyAnswered",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRecords",
                columns: table => new
                {
                    UserRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardId = table.Column<int>(type: "int", nullable: true),
                    CorrectlyAnswered = table.Column<int>(type: "int", nullable: false),
                    IncorrectlyAnswered = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecords", x => x.UserRecordId);
                    table.ForeignKey(
                        name: "FK_UserRecords_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRecords_CardId",
                table: "UserRecords",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecords_UserId",
                table: "UserRecords",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRecords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CorrectlyAnswered",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IncorrectlyAnswered",
                table: "Cards",
                nullable: false,
                defaultValue: 0);
        }
    }
}
