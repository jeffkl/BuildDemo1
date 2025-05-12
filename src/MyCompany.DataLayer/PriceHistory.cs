using System;

namespace MyCompany.DataLayer
{
    /// <summary>
    /// Represents price history for a listing
    /// </summary>
    public class PriceHistory
    {
        /// <summary>
        /// Unique identifier for the price history entry
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key reference to the associated listing
        /// </summary>
        public int ListingID { get; set; }

        /// <summary>
        /// Date when the price was set
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Price value at the specified date
        /// </summary>
        public decimal Price { get; set; }
    }
}