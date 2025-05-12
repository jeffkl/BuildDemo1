using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ClassLibrary1;

namespace MyCompany.DataLayer
{
    public class PhotoRepository
    {
        private readonly SqlConnectionInfo _connectionInfo;

        public PhotoRepository(SqlConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;
        }

        public List<Photo> GetByListingId(int listingId)
        {
            var result = new List<Photo>();
            using (var connection = _connectionInfo.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT ListingID, Description, PhotoBytes
                    FROM Photo
                    WHERE ListingID = @ListingID";
                command.Parameters.AddWithValue("@ListingID", listingId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Photo
                        {
                            ListingID = reader.GetInt32(0),
                            Description = reader.IsDBNull(1) ? null : reader.GetString(1),
                            PhotoBytes = reader.IsDBNull(2) ? null : (byte[])reader[2]
                        });
                    }
                }
            }
            return result;
        }
    }
}