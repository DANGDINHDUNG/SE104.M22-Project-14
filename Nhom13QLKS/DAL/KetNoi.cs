using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class KetNoi
    {
        public SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-CSCM7O3;Initial Catalog=QUANLYKHACHSAN;User ID=admin;Password=123456");
        public void CheckConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
    }
}
