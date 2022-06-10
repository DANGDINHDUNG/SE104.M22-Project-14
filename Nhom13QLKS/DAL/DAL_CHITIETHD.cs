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
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("INSERT INTO CHITIETHD(MAPTP, MAHD, MADV) VALUES ('{0}', '{1}', '{2}')", chiTietHD._MAPTP, chiTietHD._MAHD, chiTietHD._MADV);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaCHITIETHD(DTO_CHITIETHD chiTietHD)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("UPDATE CHITIETHD SET MAPTP = '{0}', MAHD = '{1}', MADV = '{2}', SONGAYTHUE = '{3}'", chiTietHD._MAPTP, chiTietHD._MAHD, chiTietHD._MADV, chiTietHD._SONGAYTHUE);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaCHITIETHD(int maHD, int maPTP)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM CHITIETHD WHERE MAHD = '{0}' and MAPTP = '{1}'", maHD, maPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaCHITIETHDTheoDV(int maDV, int maPTP)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM CHITIETHD WHERE MADV = '{0}' and MAPTP = '{1}'", maDV, maPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
