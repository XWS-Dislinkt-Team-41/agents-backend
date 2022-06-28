using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Agents.Migrations
{
    public partial class M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
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
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewedCompanyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    JobPosition = table.Column<string>(nullable: true),
                    PositiveImpression = table.Column<string>(nullable: true),
                    NegativeImpression = table.Column<string>(nullable: true),
                    ProjectsImpression = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    UserEngagement = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyRegistrationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CompanyId = table.Column<long>(nullable: false),
                    CompanyId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRegistrationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyRegistrationRequests_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InterviewedCompanyId = table.Column<int>(nullable: false),
                    HR = table.Column<string>(nullable: true),
                    Technical = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interview_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobPositionPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobPosition = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Min = table.Column<double>(nullable: false),
                    Average = table.Column<double>(nullable: false),
                    Max = table.Column<double>(nullable: false),
                    ReviewsNumber = table.Column<int>(nullable: false),
                    Reviewers = table.Column<List<int>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositionPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPositionPayment_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    JobOfferId = table.Column<int>(nullable: true)
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
                    { 1, null, "C#" },
                    { 2, null, "C" },
                    { 3, null, "C++" },
                    { 4, null, "Java" },
                    { 5, null, ".NET" },
                    { 6, null, "SQL" },
                    { 7, null, "Python" },
                    { 8, null, "Go" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CompanyId",
                table: "Comment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRegistrationRequests_CompanyId1",
                table: "CompanyRegistrationRequests",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_CompanyId",
                table: "Interview",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositionPayment_CompanyId",
                table: "JobPositionPayment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobOfferId",
                table: "Skills",
                column: "JobOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "CompanyRegistrationRequests");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "JobPositionPayment");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "JobOffers");
        }
    }
}
