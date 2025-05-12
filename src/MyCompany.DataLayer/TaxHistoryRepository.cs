using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ClassLibrary1;

namespace MyCompany.DataLayer
{
    public class TaxHistoryRepository
    {
        private readonly SqlConnectionInfo _connectionInfo;

        public TaxHistoryRepository(SqlConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;
        }

        public List<TaxHistory> GetByListingId(int listingId)
        {
            var result = new List<TaxHistory>();
            using (var connection = _connectionInfo.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT ListingID, Year, Price
                    FROM TaxHistory
                    WHERE ListingID = @ListingID
                    ORDER BY Year DESC";
                command.Parameters.AddWithValue("@ListingID", listingId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new TaxHistory
                        {
                            ListingID = reader.GetInt32(0),
                            Year = reader.GetInt32(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
            }
            return result;
        }
    }
}