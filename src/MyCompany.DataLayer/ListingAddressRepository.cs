
namespace MyCompany.DataLayer
{
    public class ListingAddressRepository
    {
        private readonly SqlConnectionInfo _connectionInfo;

        public ListingAddressRepository(SqlConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;
        }

        public ListingAddress? GetByListingId(int listingId)
        {
            using (var connection = _connectionInfo.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT ListingID, Address1, Address2, City, ZipCode, State
                    FROM ListingAddress
                    WHERE ListingID = @ListingID";
                command.Parameters.AddWithValue("@ListingID", listingId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ListingAddress
                        {
                            ListingID = reader.GetInt32(0),
                            Address1 = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Address2 = reader.IsDBNull(2) ? null : reader.GetString(2),
                            City = reader.IsDBNull(3) ? null : reader.GetString(3),
                            ZipCode = reader.IsDBNull(4) ? null : reader.GetString(4),
                            State = reader.IsDBNull(5) ? null : reader.GetString(5)
                        };
                    }
                }
            }
            return null;
        }
    }
}
