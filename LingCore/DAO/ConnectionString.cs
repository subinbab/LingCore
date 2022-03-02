namespace LingCore.DAO
{
    public class ConnectionString : IConnectionString
    {
        private string connectionString;
        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            connectionString = configuration.GetValue<string>("ConnectionStrings:DbConnection");
            return connectionString;
        }

    }
}
