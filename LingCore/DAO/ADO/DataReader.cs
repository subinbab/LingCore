using System.Data.SqlClient;
using System.Reflection;

namespace LingCore.DAO.ADO
{
    public class DataReader<T>
    {
        private readonly IConnectionString _connectionString;
        public string connection;
        public DataReader()
        {

        }
        private DataReader(IConnectionString con)
        {
            _connectionString = con;
        }
        public T GetAllData(T modelData , string tableName)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            connection = configuration.GetValue<string>("ConnectionStrings:DbConnection");

            ConnectionString connectionString = new ConnectionString();
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select * from " + tableName;
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Type tModelType = modelData.GetType();
                PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();
                foreach(PropertyInfo propertyInfo in arrayPropertyInfos)
                {
                    for(int j = 0; j < 6; j++)
                    {
                        propertyInfo.SetValue(modelData, dr[j]);
                    }
                   
                }
                i++;

            }
            dr.Close();
            return modelData;
        }
    }
}
