using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCompta.Server.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class V001_FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsClosing = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeTime = table.Column<DateOnly>(type: "date", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountEnters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalValue = table.Column<float>(type: "real", nullable: false),
                    LifeTime = table.Column<DateOnly>(type: "date", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEnters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountEnters_AccountTags_TagId",
                        column: x => x.TagId,
                        principalTable: "AccountTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLinkId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountLines_Users_UserLinkId",
                        column: x => x.UserLinkId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_AccountEnters_TagId",
                table: "AccountEnters",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountLines_UserLinkId",
                table: "AccountLines",
                column: "UserLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPageLines_LinesId",
                table: "AccountPageLines",
                column: "LinesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPagePayments_AccountPageId",
                table: "AccountPagePayments",
                column: "AccountPageId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateLines_TemplateId",
                table: "TemplateLines",
                column: "TemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountEnterLines");

            migrationBuilder.DropTable(
                name: "AccountPageLines");

            migrationBuilder.DropTable(
                name: "AccountPagePayments");

            migrationBuilder.DropTable(
                name: "TemplateLines");

            migrationBuilder.DropTable(
                name: "AccountEnters");

            migrationBuilder.DropTable(
                name: "AccountPages");

            migrationBuilder.DropTable(
                name: "AccountLines");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "AccountTags");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
