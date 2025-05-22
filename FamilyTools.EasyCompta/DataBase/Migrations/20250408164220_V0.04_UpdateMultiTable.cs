using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTools.EasyCompta.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class V004_UpdateMultiTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountLines_Users_UserLinkId",
                table: "AccountLines");

            migrationBuilder.DropTable(
                name: "AccountEnterLines");

            migrationBuilder.DropTable(
                name: "AccountPageEnters");

            migrationBuilder.DropTable(
                name: "AccountPagePayments");

            migrationBuilder.DropTable(
                name: "TemplateLines");

            migrationBuilder.DropColumn(
                name: "LifeTime",
                table: "Templates");

            migrationBuilder.RenameColumn(
                name: "UserLinkId",
                table: "AccountLines",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountLines_UserLinkId",
                table: "AccountLines",
                newName: "IX_AccountLines_UserId");

            migrationBuilder.RenameColumn(
                name: "LifeTime",
                table: "AccountEnters",
                newName: "Date");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Templates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EnterId",
                table: "AccountLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "AccountEnters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentDone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentIsDone = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDone_AccountPages_PageId",
                        column: x => x.PageId,
                        principalTable: "AccountPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentDone_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateEnters",
                columns: table => new
                {
                    EntersId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateEnters", x => new { x.EntersId, x.TemplateId });
                    table.ForeignKey(
                        name: "FK_TemplateEnters_AccountEnters_EntersId",
                        column: x => x.EntersId,
                        principalTable: "AccountEnters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateEnters_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountLines_EnterId",
                table: "AccountLines",
                column: "EnterId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountEnters_PageId",
                table: "AccountEnters",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDone_PageId",
                table: "PaymentDone",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDone_UserId",
                table: "PaymentDone",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateEnters_TemplateId",
                table: "TemplateEnters",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountEnters_AccountPages_PageId",
                table: "AccountEnters",
                column: "PageId",
                principalTable: "AccountPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLines_AccountEnters_EnterId",
                table: "AccountLines",
                column: "EnterId",
                principalTable: "AccountEnters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLines_Users_UserId",
                table: "AccountLines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountEnters_AccountPages_PageId",
                table: "AccountEnters");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountLines_AccountEnters_EnterId",
                table: "AccountLines");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountLines_Users_UserId",
                table: "AccountLines");

            migrationBuilder.DropTable(
                name: "PaymentDone");

            migrationBuilder.DropTable(
                name: "TemplateEnters");

            migrationBuilder.DropIndex(
                name: "IX_AccountLines_EnterId",
                table: "AccountLines");

            migrationBuilder.DropIndex(
                name: "IX_AccountEnters_PageId",
                table: "AccountEnters");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "EnterId",
                table: "AccountLines");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "AccountEnters");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AccountLines",
                newName: "UserLinkId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountLines_UserId",
                table: "AccountLines",
                newName: "IX_AccountLines_UserLinkId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "AccountEnters",
                newName: "LifeTime");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LifeTime",
                table: "Templates",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "AccountEnterLines",
                columns: table => new
                {
                    AccountEnterId = table.Column<int>(type: "int", nullable: false),
                    LinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEnterLines", x => new { x.AccountEnterId, x.LinesId });
                    table.ForeignKey(
                        name: "FK_AccountEnterLines_AccountEnters_AccountEnterId",
                        column: x => x.AccountEnterId,
                        principalTable: "AccountEnters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountEnterLines_AccountLines_LinesId",
                        column: x => x.LinesId,
                        principalTable: "AccountLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountPageEnters",
                columns: table => new
                {
                    AccountPageId = table.Column<int>(type: "int", nullable: false),
                    EntersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPageEnters", x => new { x.AccountPageId, x.EntersId });
                    table.ForeignKey(
                        name: "FK_AccountPageEnters_AccountEnters_EntersId",
                        column: x => x.EntersId,
                        principalTable: "AccountEnters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPageEnters_AccountPages_AccountPageId",
                        column: x => x.AccountPageId,
                        principalTable: "AccountPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountPagePayments",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AccountPageId = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPagePayments", x => new { x.UserId, x.AccountPageId });
                    table.ForeignKey(
                        name: "FK_AccountPagePayments_AccountPages_AccountPageId",
                        column: x => x.AccountPageId,
                        principalTable: "AccountPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPagePayments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateLines",
                columns: table => new
                {
                    LinesId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateLines", x => new { x.LinesId, x.TemplateId });
                    table.ForeignKey(
                        name: "FK_TemplateLines_AccountLines_LinesId",
                        column: x => x.LinesId,
                        principalTable: "AccountLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateLines_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountEnterLines_LinesId",
                table: "AccountEnterLines",
                column: "LinesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPageEnters_EntersId",
                table: "AccountPageEnters",
                column: "EntersId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPagePayments_AccountPageId",
                table: "AccountPagePayments",
                column: "AccountPageId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateLines_TemplateId",
                table: "TemplateLines",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLines_Users_UserLinkId",
                table: "AccountLines",
                column: "UserLinkId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
