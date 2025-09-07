using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkFlow.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WriteDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "histories",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_histories", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_histories_users_WriterID",
                        column: x => x.WriterID,
                        principalTable: "users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "readLists",
                columns: table => new
                {
                    ReadListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_readLists", x => x.ReadListID);
                    table.ForeignKey(
                        name: "FK_readLists_users_AuthorUserID",
                        column: x => x.AuthorUserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historyLists",
                columns: table => new
                {
                    HistoryListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadListID = table.Column<int>(type: "int", nullable: false),
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historyLists", x => x.HistoryListID);
                    table.ForeignKey(
                        name: "FK_historyLists_histories_HistoryID",
                        column: x => x.HistoryID,
                        principalTable: "histories",
                        principalColumn: "HistoryID");
                    table.ForeignKey(
                        name: "FK_historyLists_readLists_ReadListID",
                        column: x => x.ReadListID,
                        principalTable: "readLists",
                        principalColumn: "ReadListID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_histories_WriterID",
                table: "histories",
                column: "WriterID");

            migrationBuilder.CreateIndex(
                name: "IX_historyLists_HistoryID",
                table: "historyLists",
                column: "HistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_historyLists_ReadListID",
                table: "historyLists",
                column: "ReadListID");

            migrationBuilder.CreateIndex(
                name: "IX_readLists_AuthorUserID",
                table: "readLists",
                column: "AuthorUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historyLists");

            migrationBuilder.DropTable(
                name: "histories");

            migrationBuilder.DropTable(
                name: "readLists");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
