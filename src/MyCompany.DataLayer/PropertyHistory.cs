using System;

namespace MyCompany.DataLayer
{
    /// <summary>
    /// Represents property transaction history for a listing
    /// </summary>
    public class PropertyHistory
    {
        /// <summary>
        /// Unique identifier for the property history entry
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Foreign key reference to the associated listing
        /// </summary>
        public int ListingID { get; set; }

        /// <summary>
        /// Type of transaction that occurred
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// Date when the transaction occurred
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Transaction price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Navigation property to the associated listing
        /// </summary>
        public Listing Listing { get; set; }
    }
}