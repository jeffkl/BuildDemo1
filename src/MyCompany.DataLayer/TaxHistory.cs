namespace MyCompany.DataLayer
{
    /// <summary>
    /// Represents tax history for a listing
    /// </summary>
    public class TaxHistory
    {
        /// <summary>
        /// Unique identifier for the tax history entry
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key reference to the associated listing
        /// </summary>
        public int ListingID { get; set; }

        /// <summary>
        /// Tax year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Tax amount for the year
        /// </summary>
        public decimal Price { get; set; }
    }
}