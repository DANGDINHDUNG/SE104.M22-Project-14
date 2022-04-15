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
    public class DAL_PHONG : KetNoi
    {
        public DataTable getDSPhong()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHONG", connection);
            DataTable dtPhong = new DataTable();
            da.Fill(dtPhong);
            return dtPhong;
        }

        public bool ThemPhong(DTO_PHONG phong)
        {
            connection.Open();
            string sql = string.Format("NSERT INTO PHONG(MAPHONG, MALP, TENPHONG, GHICHU, TRANGTHAI) VALUES ('{0}', '{1}', '{2}', '{3}','{4}')", phong._MAPHONG, phong._MALP, phong._TENPHONG, phong._GHICHU, phong._TRANGTHAI);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaPhong(DTO_PHONG phong)
        {
            connection.Open();
            string sql = string.Format("UPDATE PHONG SET MALP = '{0}', TENPHONG = '{1}', GHICHU = '{2}', TRANGTHAI = '{3}' WHERE MAPHONG = '{4}'", phong._MALP, phong._TENPHONG, phong._GHICHU, phong._TRANGTHAI, phong._MAPHONG);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaPhong(int maPhong)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM PHONG WHERE MAPHONG = '{0}')", maPhong);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool TimKiemPhong(int maPhong)
        {
            connection.Open();
            string sql = string.Format("SELECT * FROM PHONG WHERE MAPHONG = '{0}'", maPhong);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
