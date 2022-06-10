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

        public bool ThemChiTietPTP(DTO_CHITIETPTP chiTietPTP)
        {
            connection.Open();
            string sql = string.Format("INSERT INTO CHITIETPTP(MACTPTP, MAPTP, MAKH) VALUES ('{0}', '{1}', '{2}')", chiTietPTP._MACTPTP, chiTietPTP._MAPTP, chiTietPTP._MAKH);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaChiTietPTP(DTO_CHITIETPTP chiTietPTP)
        {
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
            connection.Open();
            string sql = string.Format("DELETE FROM CHITIETPTP WHERE MACTPTP = '{0}')", maCTPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        /*public bool TimKiemChiTietPTP(int maCTPTP, string maKH)
        {
            connection.Open();
            string sql = string.Format("SELECT * FROM CHITIETPTP WHERE MACTPTP='{0}' OR MAKH='{1}'", maCTPTP, maKH);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }*/
    }
}
