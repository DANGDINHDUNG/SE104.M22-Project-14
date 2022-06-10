using System;
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
    public class DAL_HOADON : KetNoi
    {
        public DataTable getHOADON()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HOADON", connection);
            DataTable dtHOADON = new DataTable();
            da.Fill(dtHOADON);
            return dtHOADON;
        }

        public bool ThemHOADON(DTO_HOADON hoaDon)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("INSERT INTO HOADON(MAKH, NGAYLAP) VALUES ('{0}', '{1}')", hoaDon._MAKH, hoaDon._NGAYLAP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaHOADON(int tongTien, int maHD)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("UPDATE HOADON SET TONGTIEN = '{0}' where MAHD = '{1}'", tongTien, maHD);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaHOADON(int maHD)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM HOADON WHERE MAHD = '{0}'", maHD);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public string GetMaHD(string maPTP)
        {
            string code = string.Empty;
            string sql = string.Format("select MAHD  from HOADON A " +
                                       "inner join CHITIETPTP B on A.MAKH = B.MAKH " +
                                       "where MAPTP = '{0}'", maPTP);
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                code = dr[0].ToString();
            }
            connection.Close();
            return code;
        }            
    }
}
