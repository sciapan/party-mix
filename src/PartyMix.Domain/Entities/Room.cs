namespace PartyMix.Domain.Entities
{
    /// <summary>
    /// Stores room entry.
    /// </summary>
    public class Room
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> entity.
        /// </summary>
        public Room()
        {
            PlaylistEntries = new HashSet<PlaylistEntry>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Id. Unique identifier.
        /// </summary>
        public Ulid Id { get; set; } = Ulid.NewUlid();
        
        /// <summary>
        /// Room name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Date of room creation.
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Hash of room password.
        /// </summary>
        public string PasswordHash { get; set; }

        #endregion

        #region Navigation properties

        /// <summary>
        /// Navigation property to related playlist entries.
        /// </summary>
        public ICollection<PlaylistEntry> PlaylistEntries { get; }

        #endregion
    }
}