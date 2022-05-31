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
            CheckConnection();
            string sql = string.Format("INSERT INTO LOAIPHONG(MALP, TENLOAIPHONG, DONGIA) VALUES ('{0}', N'{1}', '{2}')", loaiPhong._MALP, loaiPhong._TENLOAIPHONG, loaiPhong._DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaLoaiPhong(DTO_LOAIPHONG loaiPhong)
        {
            CheckConnection();
            string sql = string.Format("UPDATE LOAIPHONG SET TENLOAIPHONG = N'{0}', DONGIA = '{1}' WHERE MALP = '{2}'", loaiPhong._TENLOAIPHONG, loaiPhong._DONGIA, loaiPhong._MALP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaLoaiPhong(string maLP)
        {
            CheckConnection();
            string sql = string.Format("DELETE FROM LOAIPHONG WHERE MALP = '{0}'", maLP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public string TimKiemTheoTenLoaiPhong(string tenLP)
        {
            string maLP = string.Empty;
            CheckConnection();
            string sql = string.Format("SELECT * FROM LOAIPHONG WHERE TENLOAIPHONG = N'{0}'", tenLP);

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                maLP = sdr["MALP"].ToString();
            }
            connection.Close();
            return maLP;
        }

        public List<string> TongHopMaLoaiPhong()
        {
            List<string> listMaLoaiPhong = new List<string>();
            CheckConnection();
            string sql = string.Format("SELECT MALP FROM LOAIPHONG");

            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                listMaLoaiPhong.Add(sdr[0].ToString());
            }
            connection.Close();
            return listMaLoaiPhong;
        }
    }
}
