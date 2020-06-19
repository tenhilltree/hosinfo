using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorSecond.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    LeftMonths = table.Column<int>(nullable: false),
                    Factory = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stuff",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: true),
                    Department = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stuff", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Stuff");
        }
    }
}
