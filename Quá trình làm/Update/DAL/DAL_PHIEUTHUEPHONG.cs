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
    public class DAL_PHIEUTHUEPHONG : KetNoi
    {
        public DataTable getDSPTP()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHIEUTHUEPHONG", connection);
            DataTable dtPTP = new DataTable();
            da.Fill(dtPTP);
            return dtPTP;
        }

        public bool ThemPhieuThuePhong(DTO_PHIEUTHUEPHONG ptPhong)
        {
            connection.Open();
            string sql = string.Format("INSERT INTO PHIEUTHUEPHONG(MAPHONG, NGAYLAP, SOLUONG, DONGIA) VALUES ('{0}', '{1}', '{2}', '{3}')", ptPhong._MAPHONG, ptPhong._NGAYLAP, ptPhong._SOLUONG, ptPhong._DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaPhieuThuePhong(DTO_PHIEUTHUEPHONG ptPhong)
        {
            connection.Open();
            string sql = string.Format("UPDATE PHIEUTHUEPHONG SET MAPHONG = '{0}', NGAYLAP = '{1}', SOLUONG = '{2}', DONGIA = '{3}'", ptPhong._MAPHONG, ptPhong._NGAYLAP, ptPhong._SOLUONG, ptPhong._DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaPhieuThuePhong(string maPTP)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM PHIEUTHUEPHONG WHERE MAPTP = '{0}')", maPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        /*public bool TimKiemPhieuThuePhong(string maPTP)
        {
            connection.Open();
            string sql = string.Format("SELECT * FROM PHIEUTHUEPHONG WHERE MAPTP = '{0}'", maPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }*/
    }
}
