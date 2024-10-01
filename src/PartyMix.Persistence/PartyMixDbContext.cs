using Microsoft.EntityFrameworkCore;
using PartyMix.Domain;
using PartyMix.Persistence.Converters;
using System.Reflection;

namespace PartyMix.Persistence
{
    public class PartyMixDbContext : DbContext
    {
        public PartyMixDbContext(DbContextOptions<PartyMixDbContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<Ulid>()
                .HaveConversion<UlidToStringConverter>();
            //.HaveConversion<UlidToBytesConverter>();
        }
    }
}