using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DTO;

namespace DAL
{
    public class DAL_CHITIETPTP : KetNoi
    {
        public DataTable getDSChiTietPTP()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CHITIETPTP", connection);
            DataTable dtChiTietPTP = new DataTable();
            da.Fill(dtChiTietPTP);
            return dtChiTietPTP;
        }

        public bool ThemChiTietPTP(string maPTP, string maKH)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("INSERT INTO CHITIETPTP(MAPTP, MAKH) VALUES ('{0}', '{1}')", maPTP, maKH);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaChiTietPTP(DTO_CHITIETPTP chiTietPTP)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("UPDATE CHITIETPTP SET MAPTP = '{0}', MAKH = '{1}' WHERE MACTPTP = '{2}'", chiTietPTP._MAPTP, chiTietPTP._MAKH, chiTietPTP._MACTPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaChiTietPTP(int maCTPTP)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM CHITIETPTP WHERE MACTPTP = '{0}')", maCTPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
