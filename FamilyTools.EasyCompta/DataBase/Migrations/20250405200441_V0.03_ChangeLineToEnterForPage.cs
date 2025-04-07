using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTools.EasyCompta.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class V003_ChangeLineToEnterForPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPageLines");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "AccountPages",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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

            migrationBuilder.CreateIndex(
                name: "IX_AccountPageEnters_EntersId",
                table: "AccountPageEnters",
                column: "EntersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPageEnters");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "AccountPages");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "SurName");

            migrationBuilder.CreateTable(
                name: "AccountPageLines",
                columns: table => new
                {
                    AccountPageId = table.Column<int>(type: "int", nullable: false),
                    LinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPageLines", x => new { x.AccountPageId, x.LinesId });
                    table.ForeignKey(
                        name: "FK_AccountPageLines_AccountLines_LinesId",
                        column: x => x.LinesId,
                        principalTable: "AccountLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPageLines_AccountPages_AccountPageId",
                        column: x => x.AccountPageId,
                        principalTable: "AccountPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPageLines_LinesId",
                table: "AccountPageLines",
                column: "LinesId");
        }
    }
}
