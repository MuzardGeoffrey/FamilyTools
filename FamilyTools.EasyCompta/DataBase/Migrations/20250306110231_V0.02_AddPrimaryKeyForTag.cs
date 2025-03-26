using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCompta.Server.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class V002_AddPrimaryKeyForTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountTags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "AccountPages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AccountTags_Name",
                table: "AccountTags",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_AccountTags_Name",
                table: "AccountTags");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountTags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "AccountPages",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
