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
            SqlDataAdapter da = new SqlDataAdapter("SELECT MAPHONG, TENPHONG, TENLOAIPHONG, format(DONGIA, '###,###') 'DONGIA', GHICHU " +
                                                    "FROM PHONG INNER JOIN LOAIPHONG ON PHONG.MALP = LOAIPHONG.MALP", connection);
            DataTable dtPhong = new DataTable();
            da.Fill(dtPhong);
            return dtPhong;
        }

        public bool ThemPhong(DTO_PHONG phong)
        {
            CheckConnection();
            string sql = string.Format("INSERT INTO PHONG(MALP, TENPHONG, GHICHU, TRANGTHAI) VALUES ('{0}', N'{1}', N'{2}', N'{3}')", phong._MALP, phong._TENPHONG, phong._GHICHU, phong._TRANGTHAI);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaPhong(DTO_PHONG phong, int maPhong)
        {
            CheckConnection();
            string sql = string.Format("UPDATE PHONG SET MALP = '{0}', TENPHONG = N'{1}', GHICHU = N'{2}', TRANGTHAI = N'{3}' WHERE MAPHONG = '{4}'", phong._MALP, phong._TENPHONG, phong._GHICHU, phong._TRANGTHAI, maPhong);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaPhong(int maPhong)
        {
            CheckConnection();
            string sql = string.Format("DELETE FROM PHONG WHERE MAPHONG = '{0}'", maPhong);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool TimKiemPhong(int maPhong)
        {
            CheckConnection();
            string sql = string.Format("SELECT * FROM PHONG WHERE MAPHONG = '{0}'", maPhong);
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                if (!sdr.IsClosed)
                    sdr.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public bool TimKiemPhongTheoTen(string tenPhong)
        {
            CheckConnection();
            string sql = string.Format("SELECT * FROM PHONG WHERE TENPHONG = '{0}'", tenPhong);
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                if (!sdr.IsClosed)
                    sdr.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public DataTable getDSPhongKemTrangThai()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MAPHONG, TENPHONG, TENLOAIPHONG, format(DONGIA, '###,###') 'DONGIA', TRANGTHAI " +
                                                    "FROM PHONG INNER JOIN LOAIPHONG ON PHONG.MALP = LOAIPHONG.MALP", connection);
            DataTable dtPhong = new DataTable();
            da.Fill(dtPhong);
            return dtPhong;
        }

        public List<string> TongHopMaPhong()
        {
            List<string> listMaPhong = new List<string>();
            CheckConnection();
            string sql = string.Format("SELECT MAPHONG FROM PHONG");

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                listMaPhong.Add(sdr[0].ToString());
            }
            connection.Close();
            return listMaPhong;
        }

        public bool CheckPhongDaThue(int maPhong)
        {
            CheckConnection();
            string sql = string.Format("SELECT * FROM PHONG WHERE MAPHONG = '{0}' AND TRANGTHAI = N'Trống'", maPhong);

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (!sdr.Read())
            {
                if (!sdr.IsClosed)
                    sdr.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public int TotalRoomsCount()
        {
            int count = 0;
            CheckConnection();
            string sql = string.Format("SELECT COUNT(MAPHONG) 'Number of rooms' FROM PHONG");

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                count = int.Parse(sdr["Number of rooms"].ToString());
            }
            connection.Close();
            return count;
        }

        public string GetDonGiaTheoMaPhong(string maPhong)
        {
            string donGia = string.Empty;
            CheckConnection();
            string sql = string.Format("SELECT format(DONGIA,'###,###') FROM PHONG INNER JOIN LOAIPHONG ON PHONG.MALP = LOAIPHONG.MALP WHERE MAPHONG = " + maPhong);

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                donGia = sdr[0].ToString();
            }
            connection.Close();
            return donGia;
        }

        public DataTable getDSPhongTheoPTP(int maPTP)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT PHONG.MAPHONG, TENPHONG, PHONG.MALP, TENLOAIPHONG, format(LOAIPHONG.DONGIA, '###,###') 'DONGIA', GHICHU " +
                                                   "FROM PHONG " +
                                                   "INNER JOIN LOAIPHONG ON PHONG.MALP = LOAIPHONG.MALP " +
                                                   "inner join PHIEUTHUEPHONG on PHONG.MAPHONG = PHIEUTHUEPHONG.MAPHONG " +
                                                   "where MAPTP = " + maPTP + "", connection);
            DataTable dtPhong = new DataTable();
            da.Fill(dtPhong);
            return dtPhong;
        }

        public bool SuaTrangThaiPhong(string trangthai, string maPhong)
        {
            CheckConnection();
            string sql = string.Format("UPDATE PHONG SET TRANGTHAI = N'{0}' WHERE MAPHONG = '{1}'", trangthai, maPhong);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
