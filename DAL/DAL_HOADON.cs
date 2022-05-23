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
        bool checkFlag = false;
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
            string sql = string.Format("INSERT INTO HOADON(MAKH, NGAYLAP, DONGIA) VALUES ('{0}', '{1}', '{2}')", hoaDon._MAKH, hoaDon._NGAYLAP, hoaDon._TONGTIEN);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaHOADON(DTO_HOADON hoaDon)
        {
            connection.Open();
            string sql = string.Format("UPDATE HOADON SET MAKH = '{0}', NGAYLAP = '{1}', TONGTIEN = '{2}'", hoaDon._MAKH, hoaDon._NGAYLAP, hoaDon._TONGTIEN);
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

        public void XuatTHONGTINHD(string DONGIA, string SOLUONG)
        {
            string sql = "select DONGIA, SOLUONG from PHIEUTHUEPHONG A " + 
                         "inner join CHITIETPTP B on A.MAPTP = B.MAPTP " + 
                         "inner join KHACHHANG C on B.MAKH = C.MAKH " +
                         "where MAPTP = 4";
            SqlCommand com = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                DONGIA = dr[0].ToString();
                SOLUONG = dr[1].ToString();
            }
            connection.Close();
        }

        public void CheckLOAIKHACH()
        {
            List<string> loaiKH = new List<string>();
            string type;
            string sql = "select MALK" +
                         "from KHACHHANG A" +
                         "inner join CHITIETPTP B on A.MAKH = B.MAKH" +
                         "where MAPTP = 4";
            SqlCommand com = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                type = dr[0].ToString();
                loaiKH.Add(type);
            }
            connection.Close();

            for (int i = 0; i < loaiKH.Count; i++)
            {
                if (loaiKH[i] == "NN")
                {
                    checkFlag = true;
                }
            }
        }

        public void TinhTONGTIEN(int DONGIA, int SOLUONG)
        {
            long tongTien = 0;
            float tylePhuThu;
            string sql = "select GIATRI from THAMSO where MATHAMSO = 'TS3'";
            SqlCommand com = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                tylePhuThu =float.Parse(dr[0].ToString());
            }
            connection.Close();

            if (checkFlag == false)
            {
                if (SOLUONG >= 3)
                {
                    //tongTien = (DONGIA + DONGIA * tylePhuThu) * day;
                }
                else
                {
                    //tongTien = DONGIA * day;
                }
            }
            else
            {
                if (SOLUONG >= 3)
                {
                    //tongTien = (DONGIA + DONGIA * tylePhuThu) * day * 1.5;
                }
                else
                {
                    //tongTien = DONGIA * day * 1.5;
                }
            }
        }

    }
}
