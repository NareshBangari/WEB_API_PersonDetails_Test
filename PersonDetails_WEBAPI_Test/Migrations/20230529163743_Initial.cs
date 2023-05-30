using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonDetails_WEBAPI_Test.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonDetalisTest",
                columns: table => new
                {
                    EmailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetalisTest", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalExperiencesTest",
                columns: table => new
                {
                    CompanyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TechnologyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkedTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonDetailsEmailId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalExperiencesTest", x => x.CompanyName);
                    table.ForeignKey(
                        name: "FK_TechnicalExperiencesTest_PersonDetalisTest_PersonDetailsEmailId",
                        column: x => x.PersonDetailsEmailId,
                        principalTable: "PersonDetalisTest",
                        principalColumn: "EmailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalExperiencesTest_PersonDetailsEmailId",
                table: "TechnicalExperiencesTest",
                column: "PersonDetailsEmailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechnicalExperiencesTest");

            migrationBuilder.DropTable(
                name: "PersonDetalisTest");
        }
    }
}
