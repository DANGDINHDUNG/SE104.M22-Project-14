using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL
{
    public class KetNoi
    {
        protected SqlConnection connection = new SqlConnection(@"Data Source=ADMINISTRATORSQLEXPRESS;Initial Catalog=ThanhVien;Integrated Security=True");
    }
}
