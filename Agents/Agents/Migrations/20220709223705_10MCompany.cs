using Microsoft.EntityFrameworkCore.Migrations;

namespace Agents.Migrations
{
    public partial class _10MCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityDescription",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInformation",
                table: "Company",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$IsNh0Bb.4naSXZa4tzrbn.eoqyCXcxtmy/jDfhvKd3zADda7TmR2e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$11$85lkTgKlL6a/D6eTWzKOMeb70Du/qj5xL1xrjj7.I/m4xytpopN3m");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityDescription",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ContactInformation",
                table: "Company");

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
        }
    }
}
