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
    public class DAL_LOAIPHONG : KetNoi
    {
        public DataTable getDSLoaiPhong()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LOAIPHONG", connection);
            DataTable dtLoaiPhong = new DataTable();
            da.Fill(dtLoaiPhong);
            return dtLoaiPhong;
        }

        public bool ThemLoaiPhong(DTO_LOAIPHONG loaiPhong)
        {
            connection.Open();
            string sql = string.Format("NSERT INTO LOAIPHONG(MALP, TENLOAIPHONG, DONGIA) VALUES ('{0}', '{1}', '{2}')", loaiPhong._MALP, loaiPhong._TENLOAIPHONG, loaiPhong._DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaLoaiPhong(DTO_LOAIPHONG loaiPhong)
        {
            connection.Open();
            string sql = string.Format("UPDATE LOAIPHONG SET TENLOAIPHONG = '{0}', DONGIA = '{1}' WHERE MALP = '{2}'", loaiPhong._TENLOAIPHONG, loaiPhong._DONGIA, loaiPhong._MALP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaLoaiPhong(string maLP)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM LOAIPHONG WHERE MALP = '{0}')", maLP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool TimKiemTheoLoaiPhong(string maLP)
        {
            connection.Open();
            string sql = string.Format("SELECT * FROM PHONG WHERE MALP = '{0}'", maLP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
