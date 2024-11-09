using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PartyMix.Domain.Entities;

namespace PartyMix.Persistence.Configurations;

internal class PlaylistEntryConfiguration: IEntityTypeConfiguration<PlaylistEntry>
{
    public void Configure(EntityTypeBuilder<PlaylistEntry> builder)
    {
        // table name
        builder.ToTable("playlist_entries");
        
        // primary key
        builder.HasKey(x => x.Id).HasName("pk_playlist_entries");
        
        // properties options
        builder.Property(x => x.Artist).HasMaxLength(256).IsRequired();
        builder.Property(x => x.Song).HasMaxLength(256).IsRequired();
        
        // indexes
        builder.HasIndex(x => x.RoomId).HasDatabaseName("playlist_entries_room_id_idx");
        
        // fk
        builder.HasOne(x => x.Room)
            .WithMany(x => x.PlaylistEntries)
            .HasForeignKey(x => x.RoomId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_playlist_entries_rooms");
    }
}