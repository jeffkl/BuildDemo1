using System.Collections.Generic;

namespace MyCompany.DataLayer
{
    public class PriceHistoryRepository
    {
        private readonly SqlConnectionInfo _connectionInfo;

        public PriceHistoryRepository(SqlConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;
        }

        public List<PriceHistory> GetByListingId(int listingId)
        {
            var result = new List<PriceHistory>();
            using (var connection = _connectionInfo.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT ListingID, Date, Price
                    FROM PriceHistory
                    WHERE ListingID = @ListingID
                    ORDER BY Date DESC";
                command.Parameters.AddWithValue("@ListingID", listingId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new PriceHistory
                        {
                            ListingID = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            Price = reader.GetDecimal(2)
                        });
                    }
                }
            }
            return result;
        }
    }
}