using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PartyMix.Domain.Entities;

namespace PartyMix.Persistence.Configurations
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // table name
            builder.ToTable("rooms");

            // primary key
            builder.HasKey(x => x.Id).HasName("pk_rooms");

            // properties options
            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
            builder.Property(x => x.CreationDate).HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(x => x.PasswordHash).IsRequired();
        }
    }
}