namespace MyCompany.DataLayer
{
    /// <summary>
    /// Represents a photo associated with a listing
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Unique identifier for the photo
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key reference to the associated listing
        /// </summary>
        public int ListingID { get; set; }

        /// <summary>
        /// Description or caption for the photo
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Binary data for the photo image
        /// </summary>
        public byte[] PhotoBytes { get; set; }

        /// <summary>
        /// Navigation property to the associated listing
        /// </summary>
        public Listing Listing { get; set; }
    }
}