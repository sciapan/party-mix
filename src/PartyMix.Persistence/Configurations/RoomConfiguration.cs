using Microsoft.EntityFrameworkCore;
using PartyMix.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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