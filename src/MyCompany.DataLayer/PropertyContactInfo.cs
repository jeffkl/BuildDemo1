namespace MyCompany.DataLayer
{
    /// <summary>
    /// Represents contact information for a property
    /// </summary>
    public class PropertyContactInfo
    {
        public static PropertyContactInfo None = new PropertyContactInfo
        {
            ID = 0,
            ListingID = 0,
            Name = string.Empty,
            Address = string.Empty,
            Phone = string.Empty
        };

        /// <summary>
        /// Unique identifier for the contact information
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key reference to the associated listing
        /// </summary>
        public int ListingID { get; set; }

        /// <summary>
        /// Name of the contact person
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Contact address
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Contact phone number
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Navigation property to the associated listing
        /// </summary>
        public Listing Listing { get; set; } = Listing.None;
    }
}