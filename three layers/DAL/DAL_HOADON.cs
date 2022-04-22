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
            connection.Open();
            string sql = string.Format("INSERT INTO HOADON(MAKH, NGAYLAP, DONGIA) VALUES ('{0}', '{1}', '{2}')", hoaDon._MAKH, hoaDon._NGAYLAP, hoaDon._DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaHOADON(DTO_HOADON hoaDon)
        {
            connection.Open();
            string sql = string.Format("UPDATE HOADON SET MAKH = '{0}', NGAYLAP = '{1}', DONGIA = '{2}'", hoaDon._MAKH, hoaDon._NGAYLAP, hoaDon._DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaHOADON(int maHD)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM HOADON WHERE MABCDT = '{0}')", maHD);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
