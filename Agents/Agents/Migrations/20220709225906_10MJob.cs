using Microsoft.EntityFrameworkCore.Migrations;

namespace Agents.Migrations
{
    public partial class _10MJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "$2a$11$i.Wr4UOKFmgLebB5jbSM1uJd9gkp1Uo70MnABa0EWA8zuHFwWmRWG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "$2a$11$Hp2N8Eeh0E/CX9Ds3WS9YeBD.3bzcBK6EzUO3z5ZYg/30Z2IrAopG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
