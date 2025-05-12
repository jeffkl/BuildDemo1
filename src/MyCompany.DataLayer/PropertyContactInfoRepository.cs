namespace MyCompany.DataLayer
{
    public class PropertyContactInfoRepository
    {
        private readonly SqlConnectionInfo _connectionInfo;

        public PropertyContactInfoRepository(SqlConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;
        }

        public PropertyContactInfo? GetByListingId(int listingId)
        {
            using (var connection = _connectionInfo.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT ListingID, Name, Address, Phone
                    FROM PropertyContactInfo
                    WHERE ListingID = @ListingID";
                command.Parameters.AddWithValue("@ListingID", listingId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PropertyContactInfo
                        {
                            ListingID = reader.GetInt32(0),
                            Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Address = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Phone = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                    }
                }
            }
            return null;
        }
    }
}