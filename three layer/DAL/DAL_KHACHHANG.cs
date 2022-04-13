using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_KHACHHANG:KetNoi
    {
        public DataTable getTaiKhoan()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG", connection);
            DataTable dtKHACHHANG = new DataTable();
            da.Fill(dtKHACHHANG);
            return dtKHACHHANG;
        }
        public bool ThemKhachHang(DTO_KHACHHANG kh)
        {
            connection.Open();
            string sql = string.Format("INSERT INTO KHACHHANG(MAKH, MALK, HOTEN,CMND_CCCD,SDT,GIOITINH,TUOI) VALUES ('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}')", kh.MAKH, kh.MALK, kh.HOTEN, kh.CMND,kh.SDT,kh.TUOI);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaKhachHang(DTO_KHACHHANG kh)
        {
            connection.Open();
            string sql = string.Format("UPDATE KHACHHANG SET HOTEN='{0}', CMND_CCCD='{1}', SDT='{2}',GIOITINH='{3}',TUOI='{4}'", kh.HOTEN, kh.SDT, kh.GIOITINH, kh.TUOI);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaKhachHang(string makh)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM KHACHHANG WHERE MAKH = '{0}')", makh);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool TimKiemKhachHang(string s)
        {
            connection.Open();
            string sql = string.Format("SELECT * FROM KHACHHANG WHERE HOTEN='{0}%' ",s);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
