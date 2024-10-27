using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PartyMix.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddPlaylistEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playlist_entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Singer = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Song = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_playlist_entries", x => x.Id);
                    table.ForeignKey(
                        name: "fk_playlist_entries_rooms",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "playlist_entries_room_id_idx",
                table: "playlist_entries",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlist_entries");
        }
    }
}
