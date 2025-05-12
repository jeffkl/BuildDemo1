using Microsoft.Data.SqlClient;

namespace MyCompany.DataLayer
{
    public sealed class SqlConnectionInfo
    {
        public SqlConnectionInfo(string server, string initialCatalog = "")
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = initialCatalog,
                IntegratedSecurity = true,
            };

            ConnectionString = builder.ConnectionString;
        }

        public string ConnectionString { get; private set; }

        public SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
