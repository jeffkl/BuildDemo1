using System;

namespace MyCompany.DataLayer
{
    public class ListingRepository
    {
        private readonly SqlConnectionInfo _connectionInfo;

        public ListingRepository(SqlConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo ?? throw new ArgumentNullException(nameof(connectionInfo));
        }

        public Listing? GetListingById(int id)
        {
            using (var connection = _connectionInfo.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT ID, PropertyType, ListingDate, BedroomCount, BathroomCount, YearBuilt, Tags, Description, HOADues, LotSquareFeet, HouseSquareFeet, ViewCount
                    FROM Listings
                    WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    var listing = new Listing
                    {
                        ID = reader.GetInt32(0),
                        PropertyType = (PropertyType)reader.GetInt32(1),
                        ListingDate = reader.GetDateTime(2),
                        BedroomCount = reader.GetInt32(3),
                        BathroomCount = reader.GetDecimal(4),
                        YearBuilt = reader.GetInt32(5),
                        Tags = reader.IsDBNull(6) ? new System.Collections.Generic.List<string>() : [.. reader.GetString(6).Split(',')],
                        Description = reader.IsDBNull(7) ? null : reader.GetString(7),
                        HOADues = reader.IsDBNull(8) ? (decimal?)null : reader.GetDecimal(8),
                        LotSquareFeet = reader.GetDecimal(9),
                        HouseSquareFeet = reader.GetDecimal(10),
                        ViewCount = reader.GetInt32(11)
                    };
                    return listing;
                }
            }
        }
    }
}