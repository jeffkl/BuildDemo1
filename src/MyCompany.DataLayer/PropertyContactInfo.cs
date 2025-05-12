namespace MyCompany.DataLayer
{
    /// <summary>
    /// Represents contact information for a property
    /// </summary>
    public class PropertyContactInfo
    {
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
        public string? Name { get; set; }

        /// <summary>
        /// Contact address
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Contact phone number
        /// </summary>
        public string? Phone { get; set; }
    }
}