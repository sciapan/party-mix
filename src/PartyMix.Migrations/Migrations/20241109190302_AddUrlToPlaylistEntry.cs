using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyMix.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlToPlaylistEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Singer",
                table: "playlist_entries",
                newName: "Artist");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "playlist_entries",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "playlist_entries");

            migrationBuilder.RenameColumn(
                name: "Artist",
                table: "playlist_entries",
                newName: "Singer");
        }
    }
}
