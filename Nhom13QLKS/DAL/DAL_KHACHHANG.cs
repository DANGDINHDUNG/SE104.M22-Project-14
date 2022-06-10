using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_KHACHHANG : KetNoi
    {
        public DataTable getKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG", connection);
            DataTable dtKHACHHANG = new DataTable();
            da.Fill(dtKHACHHANG);
            return dtKHACHHANG;
        }

        public DataTable getLoaiKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT KHACHHANG.*,TENLOAIKHACH FROM KHACHHANG INNER JOIN LOAIKHACH ON KHACHHANG.MALK=LOAIKHACH.MALK", connection);
            DataTable dtKHACHHANG = new DataTable();
            da.Fill(dtKHACHHANG);
            return dtKHACHHANG;
        }
        public bool ThemKhachHang(DTO_KHACHHANG kh)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("INSERT INTO KHACHHANG(MALK, TENKH,CMND,DIACHI) VALUES ('{0}', N'{1}', '{2}',N'{3}')", kh.MALK, kh.TENKH, kh.CMND, kh.DIACHI);
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                if (!reader.IsClosed)
                    reader.Close();
                return true;

            }
            if (!reader.IsClosed)
                reader.Close();
            return false;
            connection.Close();
        }

        public bool SuaKhachHang(DTO_KHACHHANG kh)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("UPDATE KHACHHANG SET TENKH=N'{0}', CMND='{1}', MALK='{2}',DIACHI=N'{3}' WHERE MAKH = '{4}'", kh.TENKH, kh.CMND, kh.MALK, kh.DIACHI, kh.MAKH);
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                if (!reader.IsClosed)
                    reader.Close();
                return true;

            }
            if (!reader.IsClosed)
                reader.Close();
            return false;
            connection.Close();
        }

        public bool XoaKhachHang(int makh)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM KHACHHANG WHERE MAKH = '{0}'", makh);
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                if (!reader.IsClosed)
                    reader.Close();
                return true;

            }
            if (!reader.IsClosed)
                reader.Close();
            return false;
            connection.Close();
        }

        public DataTable TimKiemKhachHang(string s)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG WHERE TENKH LIKE N'" + s + "%' ", connection);
            DataTable dtKHACHHANG = new DataTable();
            da.Fill(dtKHACHHANG);
            return dtKHACHHANG;
        }

        public DataTable getKhachHangTrongPTP(int maptp)
        {
            SqlDataAdapter da = new SqlDataAdapter("select A.MAKH, MALK, TENKH, CMND, DIACHI " +
                                                   "from KHACHHANG A " +
                                                   "inner join CHITIETPTP B on A.MAKH = B.MAKH " +
                                                   "where MAPTP = '" + maptp + "'", connection);
            DataTable dtKHACHHANG = new DataTable();
            da.Fill(dtKHACHHANG);
            return dtKHACHHANG;
        }
    }
}
