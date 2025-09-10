using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InkFlow.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historyLists");

            migrationBuilder.DropTable(
                name: "histories");

            migrationBuilder.RenameColumn(
                name: "WriteDescription",
                table: "users",
                newName: "WriterDescription");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "stories",
                columns: table => new
                {
                    StoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stories", x => x.StoryID);
                    table.ForeignKey(
                        name: "FK_stories_users_WriterID",
                        column: x => x.WriterID,
                        principalTable: "users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "storyLists",
                columns: table => new
                {
                    StoryListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadListID = table.Column<int>(type: "int", nullable: false),
                    StoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storyLists", x => x.StoryListID);
                    table.ForeignKey(
                        name: "FK_storyLists_readLists_ReadListID",
                        column: x => x.ReadListID,
                        principalTable: "readLists",
                        principalColumn: "ReadListID");
                    table.ForeignKey(
                        name: "FK_storyLists_stories_StoryID",
                        column: x => x.StoryID,
                        principalTable: "stories",
                        principalColumn: "StoryID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_stories_WriterID",
                table: "stories",
                column: "WriterID");

            migrationBuilder.CreateIndex(
                name: "IX_storyLists_ReadListID",
                table: "storyLists",
                column: "ReadListID");

            migrationBuilder.CreateIndex(
                name: "IX_storyLists_StoryID",
                table: "storyLists",
                column: "StoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "storyLists");

            migrationBuilder.DropTable(
                name: "stories");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "WriterDescription",
                table: "users",
                newName: "WriteDescription");

            migrationBuilder.CreateTable(
                name: "histories",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "historyLists",
                columns: table => new
                {
                    HistoryListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoryID = table.Column<int>(type: "int", nullable: false),
                    ReadListID = table.Column<int>(type: "int", nullable: false)
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
        }
    }
}
