using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Bankomat
{
    class DataAccessLayer
    {
        public void getAccounts()
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\App_Data\\Database1.mdf;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("select * from BankAccounts;", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                foreach(IDataRecord record in reader)
                {
                    object id = record["Balance"];
                    Console.WriteLine(id);
                }
            }
            command.Dispose();
            connection.Close();
        }
    }
}
