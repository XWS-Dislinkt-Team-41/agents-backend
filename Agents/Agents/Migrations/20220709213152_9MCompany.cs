using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Agents.Migrations
{
    public partial class _9MCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Grade = table.Column<float>(nullable: false),
                    UsersGrade = table.Column<List<int>>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewedCompanyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    JobPosition = table.Column<string>(nullable: true),
                    PositiveImpression = table.Column<string>(nullable: true),
                    NegativeImpression = table.Column<string>(nullable: true),
                    ProjectsImpression = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    UserEngagement = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true)
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
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InterviewedCompanyId = table.Column<int>(nullable: false),
                    HR = table.Column<string>(nullable: true),
                    Technical = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<long>(nullable: true)
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobPosition = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Min = table.Column<double>(nullable: false),
                    Average = table.Column<double>(nullable: false),
                    Max = table.Column<double>(nullable: false),
                    ReviewsNumber = table.Column<int>(nullable: false),
                    Reviewers = table.Column<List<int>>(nullable: true),
                    CompanyId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositionPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPositionPayment_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Grade", "Image", "Name", "UsersGrade" },
                values: new object[,]
                {
                    { 1L, 0f, "https://upload.wikimedia.org/wikipedia/commons/9/9d/Flag_of_Arkansas.svg", "Arkansas", null },
                    { 2L, 0f, "https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Florida.svg", "Florida", null },
                    { 3L, 0f, "https://upload.wikimedia.org/wikipedia/commons/f/f7/Flag_of_Texas.svg", "Texas", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$qdFjBgtTQrojuwI.TOkd.OfaJH9M3zwxFk/g20y25Swsa/yhlHPPO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$11$yjRs6dvNUpl/joh2kETGgeWmFC.XoY5T3ep.0JZ31pNYCwFFx50ha");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CompanyId",
                table: "Comment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_CompanyId",
                table: "Interview",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositionPayment_CompanyId1",
                table: "JobPositionPayment",
                column: "CompanyId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "JobPositionPayment");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$m2.lUKjrD3ikglgLh.kNk.Chdvu5YmQDEJwQqYdocFeuaaGLqI6Mi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$11$ZFhGje6Q/LTcP4o3XJvyde19EK0PYxFfAwbAuT5gHvgE3McREf946");
        }
    }
}
