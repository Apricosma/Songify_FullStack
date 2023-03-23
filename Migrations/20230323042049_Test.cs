using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Songify_FullStack.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibrarySong_Song_SongId",
                table: "LibrarySong");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Song_SongId",
                table: "PlaylistSong");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropTable(
                name: "SongContributor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "mediaItems");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "mediaTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Song_AlbumId",
                table: "mediaItems",
                newName: "IX_mediaItems_AlbumId");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "mediaItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "AirDate",
                table: "mediaItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MediaItemType",
                table: "mediaItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PodcastId",
                table: "mediaItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "mediaTypes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "MediaType",
                table: "mediaTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mediaItems",
                table: "mediaItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mediaTypes",
                table: "mediaTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Contributor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    PodcastId = table.Column<int>(type: "int", nullable: true),
                    SongId = table.Column<int>(type: "int", nullable: true),
                    EpisodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributor_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contributor_mediaItems_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "mediaItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contributor_mediaItems_SongId",
                        column: x => x.SongId,
                        principalTable: "mediaItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contributor_mediaTypes_PodcastId",
                        column: x => x.PodcastId,
                        principalTable: "mediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mediaItems_PodcastId",
                table: "mediaItems",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributor_ArtistId",
                table: "Contributor",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributor_EpisodeId",
                table: "Contributor",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributor_PodcastId",
                table: "Contributor",
                column: "PodcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributor_SongId",
                table: "Contributor",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibrarySong_mediaItems_SongId",
                table: "LibrarySong",
                column: "SongId",
                principalTable: "mediaItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_mediaItems_mediaTypes_AlbumId",
                table: "mediaItems",
                column: "AlbumId",
                principalTable: "mediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_mediaItems_mediaTypes_PodcastId",
                table: "mediaItems",
                column: "PodcastId",
                principalTable: "mediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_mediaItems_SongId",
                table: "PlaylistSong",
                column: "SongId",
                principalTable: "mediaItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibrarySong_mediaItems_SongId",
                table: "LibrarySong");

            migrationBuilder.DropForeignKey(
                name: "FK_mediaItems_mediaTypes_AlbumId",
                table: "mediaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_mediaItems_mediaTypes_PodcastId",
                table: "mediaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_mediaItems_SongId",
                table: "PlaylistSong");

            migrationBuilder.DropTable(
                name: "Contributor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mediaTypes",
                table: "mediaTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mediaItems",
                table: "mediaItems");

            migrationBuilder.DropIndex(
                name: "IX_mediaItems_PodcastId",
                table: "mediaItems");

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "mediaTypes");

            migrationBuilder.DropColumn(
                name: "AirDate",
                table: "mediaItems");

            migrationBuilder.DropColumn(
                name: "MediaItemType",
                table: "mediaItems");

            migrationBuilder.DropColumn(
                name: "PodcastId",
                table: "mediaItems");

            migrationBuilder.RenameTable(
                name: "mediaTypes",
                newName: "Album");

            migrationBuilder.RenameTable(
                name: "mediaItems",
                newName: "Song");

            migrationBuilder.RenameIndex(
                name: "IX_mediaItems_AlbumId",
                table: "Song",
                newName: "IX_Song_AlbumId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Album",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SongContributor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongContributor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongContributor_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongContributor_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongContributor_ArtistId",
                table: "SongContributor",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SongContributor_SongId",
                table: "SongContributor",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibrarySong_Song_SongId",
                table: "LibrarySong",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Song_SongId",
                table: "PlaylistSong",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
