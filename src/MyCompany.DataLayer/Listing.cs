using System;
using System.Collections.Generic;

namespace MyCompany.DataLayer
{
    /// <summary>
    /// Represents a real estate listing
    /// </summary>
    public class Listing
    {
        /// <summary>
        /// Unique identifier for the listing
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Type of property (Single Family House, Multi-family House, Condo, Lot)
        /// </summary>
        public PropertyType PropertyType { get; set; }

        /// <summary>
        /// Date when the listing was created
        /// </summary>
        public DateTime ListingDate { get; set; }

        /// <summary>
        /// Number of bedrooms in the property
        /// </summary>
        public int BedroomCount { get; set; }

        /// <summary>
        /// Number of bathrooms in the property (can be a fractional number)
        /// </summary>
        public decimal BathroomCount { get; set; }

        /// <summary>
        /// Year the property was built
        /// </summary>
        public int YearBuilt { get; set; }

        /// <summary>
        /// Keywords/tags associated with the listing
        /// </summary>
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// Detailed description of the property
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Monthly HOA (Homeowner Association) dues
        /// </summary>
        public decimal? HOADues { get; set; }

        /// <summary>
        /// Size of the lot in square feet
        /// </summary>
        public decimal LotSquareFeet { get; set; }

        /// <summary>
        /// Size of the house in square feet
        /// </summary>
        public decimal HouseSquareFeet { get; set; }

        /// <summary>
        /// Number of times the listing has been viewed
        /// </summary>
        public int ViewCount { get; set; }

        // Navigation properties for related entities
        /// <summary>
        /// Price history entries for this listing
        /// </summary>
        public List<PriceHistory> PriceHistory { get; set; } = new List<PriceHistory>();

        /// <summary>
        /// Address information for this listing
        /// </summary>
        public ListingAddress? Address { get; set; }

        /// <summary>
        /// Photos associated with this listing
        /// </summary>
        public List<Photo> Photos { get; set; } = new List<Photo>();

        /// <summary>
        /// Property history entries for this listing
        /// </summary>
        public List<PropertyHistory> PropertyHistory { get; set; } = new List<PropertyHistory>();

        /// <summary>
        /// Tax history entries for this listing
        /// </summary>
        public List<TaxHistory> TaxHistory { get; set; } = new List<TaxHistory>();

        /// <summary>
        /// Contact information for this listing
        /// </summary>
        public PropertyContactInfo? ContactInfo { get; set; }
    }
}