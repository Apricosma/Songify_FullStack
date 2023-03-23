using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Songify_FullStack.Migrations
{
    /// <inheritdoc />
    public partial class TestListenerLists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListenerListId",
                table: "PlaylistSong",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListenerList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListenerList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListenerListPodcasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PodcastId = table.Column<int>(type: "int", nullable: false),
                    ListenerListId = table.Column<int>(type: "int", nullable: false),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenerListPodcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListenerListPodcasts_ListenerList_ListenerListId",
                        column: x => x.ListenerListId,
                        principalTable: "ListenerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListenerListPodcasts_mediaTypes_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "mediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSong_ListenerListId",
                table: "PlaylistSong",
                column: "ListenerListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerList_UserId",
                table: "ListenerList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerListPodcasts_ListenerListId",
                table: "ListenerListPodcasts",
                column: "ListenerListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListenerListPodcasts_PodcastId",
                table: "ListenerListPodcasts",
                column: "PodcastId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_ListenerList_ListenerListId",
                table: "PlaylistSong",
                column: "ListenerListId",
                principalTable: "ListenerList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_ListenerList_ListenerListId",
                table: "PlaylistSong");

            migrationBuilder.DropTable(
                name: "ListenerListPodcasts");

            migrationBuilder.DropTable(
                name: "ListenerList");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistSong_ListenerListId",
                table: "PlaylistSong");

            migrationBuilder.DropColumn(
                name: "ListenerListId",
                table: "PlaylistSong");
        }
    }
}
