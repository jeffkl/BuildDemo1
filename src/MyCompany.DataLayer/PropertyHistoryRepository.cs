using System.Collections.Generic;

namespace MyCompany.DataLayer
{
    public class PropertyHistoryRepository
    {
        private readonly SqlConnectionInfo _connectionInfo;

        public PropertyHistoryRepository(SqlConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;
        }

        public List<PropertyHistory> GetByListingId(int listingId)
        {
            var result = new List<PropertyHistory>();
            using (var connection = _connectionInfo.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT ListingID, TransactionType, Date, Price
                    FROM PropertyHistory
                    WHERE ListingID = @ListingID
                    ORDER BY Date DESC";
                command.Parameters.AddWithValue("@ListingID", listingId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new PropertyHistory
                        {
                            ListingID = reader.GetInt32(0),
                            TransactionType = (TransactionType)reader.GetInt32(1),
                            Date = reader.GetDateTime(2),
                            Price = reader.GetDecimal(3)
                        });
                    }
                }
            }
            return result;
        }
    }
}