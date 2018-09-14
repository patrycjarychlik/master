using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdeToFood.Migrations
{
    public partial class Nowe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Text = table.Column<string>(maxLength: 5000, nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ReviewId = table.Column<string>(nullable: true),
                    restaurantId = table.Column<string>(nullable: true),
                    Stars = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

       

  
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
       

            migrationBuilder.DropTable(
                name: "Reviews");

          
        }
    }
}
