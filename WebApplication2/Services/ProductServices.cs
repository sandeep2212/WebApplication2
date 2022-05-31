using System.Data.SqlClient;
using WebApplication2.Model;

namespace WebApplication2.Services
{
    public class ProductServices
    {
        private static string db_source = "appdbserver3000.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "S@ndeep12345";
        private static string db_databasename = "appdb";

        private SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.UserID = db_user;
            builder.Password = db_password;
            builder.InitialCatalog = db_databasename;

            return new SqlConnection(builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            var connection=GetConnection();
            var products = new List<Product>();
            connection.Open();
            var query = "Select * from Products";

            var command = new SqlCommand(query, connection);
            using (SqlDataReader? reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Product product = new()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                    };

                    products.Add(product);
                }
            }
            connection.Close();
            return products;
        }
    }
    }

