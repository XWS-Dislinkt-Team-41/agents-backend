﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Agents.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyRegistrationRequests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRegistrationRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<long>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    Seniority = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    Confirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    JobOfferId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "JobOfferId", "Name" },
                values: new object[,]
                {
                    { 1L, null, "C#" },
                    { 2L, null, "C" },
                    { 3L, null, "C++" },
                    { 4L, null, "Java" },
                    { 5L, null, ".NET" },
                    { 6L, null, "SQL" },
                    { 7L, null, "Python" },
                    { 8L, null, "Go" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobOfferId",
                table: "Skills",
                column: "JobOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyRegistrationRequests");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JobOffers");
        }
    }
}
