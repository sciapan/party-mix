namespace PartyMix.Domain
{
    public class Room
    {
        public Ulid Id { get; set; } = Ulid.NewUlid();

        public string Name { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public string PasswordHash { get; set; }
    }
}