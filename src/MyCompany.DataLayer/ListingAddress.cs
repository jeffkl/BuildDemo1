namespace MyCompany.DataLayer
{
    /// <summary>
    /// Represents address information for a listing
    /// </summary>
    public class ListingAddress
    {
        public static ListingAddress None = new ListingAddress
        {
            ID = 0,
            ListingID = 0,
            Address1 = string.Empty,
            Address2 = string.Empty,
            City = string.Empty,
            ZipCode = string.Empty,
            State = string.Empty
        };

        /// <summary>
        /// Unique identifier for the address entry
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key reference to the associated listing
        /// </summary>
        public int ListingID { get; set; }

        /// <summary>
        /// Primary address line
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Secondary address line (apartment, unit, etc.)
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// ZIP/Postal code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// State/Province
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Navigation property to the associated listing
        /// </summary>
        public Listing Listing { get; set; } = Listing.None;
    }
}