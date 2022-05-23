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
    public class DAL_CHITIETHD : KetNoi
    {
        public DataTable getDSCHITIETHD()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CHITIETHD", connection);
            DataTable dtCHITIETHD = new DataTable();
            da.Fill(dtCHITIETHD);
            return dtCHITIETHD;
        }

        public bool ThemCHITIETHD(DTO_CHITIETHD chiTietHD)
        {
            connection.Open();
            string sql = string.Format("INSERT INTO CHITIETHD(MAPTP, MAHD, MADV, SONGAYTHUE) VALUES ('{0}', '{1}', '{2}', '{3}')", chiTietHD._MAPTP, chiTietHD._MAHD, chiTietHD._MADV, chiTietHD._SONGAYTHUE);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaCHITIETHD(DTO_CHITIETHD chiTietHD)
        {
            connection.Open();
            string sql = string.Format("UPDATE CHITIETHD SET MAPTP = '{0}', MAHD = '{1}', MADV = '{2}', SONGAYTHUE = '{3}'", chiTietHD._MAPTP, chiTietHD._MAHD, chiTietHD._MADV, chiTietHD._SONGAYTHUE);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaCHITIETHD(int maCTHD)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM CHITIETHD WHERE MACTHD = '{0}')", maCTHD);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public void TinhSONGAYTHUE(DateTime NGAYLAP, DateTime NGAYTRA)
        {
            string sql = "select top 1 C.MAKH, TENKH, NGAYLAP " +
                         "from PHIEUTHUEPHONG A " +
                         "inner join CHITIETPTP B on A.MAPTP = B.MAPTP " +
                         "inner join KHACHHANG C on B.MAKH = C.MAKH " +
                         "where A.MAPTP = 4";
            SqlCommand com = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                NGAYLAP = DateTime.Parse(dr[2].ToString());
            }
            connection.Close();
            // datetimepicker1: NGAYLAP từ PHIẾU THUÊ PHÒNG || datetimepicker2: DateTime.Now (NGAYLAP HOADON)
            TimeSpan timeSpan = NGAYTRA - NGAYLAP;
            int diffDays = timeSpan.Days + 1;
            decimal day = Convert.ToDecimal(diffDays);
        }
    }
}
