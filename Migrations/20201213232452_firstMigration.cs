using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Insurance_policy.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsurancePolicy",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    number = table.Column<string>(nullable: true),
                    dateOfCreation = table.Column<DateTime>(nullable: false),
                    fullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicy", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsurancePolicy");
        }
    }
}
