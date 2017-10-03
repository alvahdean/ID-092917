using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IDSkills.WebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FolkFields",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolkFields", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Folks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bio = table.Column<string>(maxLength: 4096, nullable: true),
                    BirthLocation = table.Column<string>(maxLength: 80, nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    FolkFieldID = table.Column<int>(nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Folks_FolkFields_FolkFieldID",
                        column: x => x.FolkFieldID,
                        principalTable: "FolkFields",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folks_FolkFieldID",
                table: "Folks",
                column: "FolkFieldID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folks");

            migrationBuilder.DropTable(
                name: "FolkFields");
        }
    }
}
