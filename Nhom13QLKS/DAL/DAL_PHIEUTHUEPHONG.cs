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
    public class DAL_PHIEUTHUEPHONG : KetNoi
    {
        public DataTable getDSPTP()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MAPTP, MAPHONG, FORMAT(NGAYLAP, 'dd/MM/yyyy') 'NGAYLAP', SOLUONG, FORMAT(DONGIA, '###,###') 'DONGIA', TINHTRANG" +
                                                   " FROM PHIEUTHUEPHONG WHERE TINHTRANG = 'Chưa thanh toán'", connection);
            DataTable dtPTP = new DataTable();
            da.Fill(dtPTP);
            return dtPTP;
        }

        public DataTable getDSPTPKemKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("select MAPTP, MAPHONG, NGAYLAP, SOLUONG, FORMAT(DONGIA, '###,###') 'DONGIA', TENKH, MAKH, TINHTRANG " +
                                                    "from " +
                                                    "( " +
                                                        "SELECT  A.MAPTP, MAPHONG, NGAYLAP, SOLUONG,DONGIA, TENKH, TINHTRANG, B.MAKH,RANK() OVER (PARTITION BY A.MAPTP ORDER BY MAX(B.MAKH) ASC) AS XEPHANG " +
                                                        "from PHIEUTHUEPHONG A " +
                                                        "inner join CHITIETPTP B on A.MAPTP = B.MAPTP " +
                                                        "inner join KHACHHANG C on B.MAKH = C.MAKH " +
                                                        "	where TINHTRANG = N'Chưa thanh toán'" +
                                                        "group by A.MAPTP, MAPHONG, NGAYLAP, SOLUONG,DONGIA, TENKH, B.MAKH, TINHTRANG " +
                                                    ") as A " +
                                                    "where XEPHANG=1", connection); ;
            DataTable dtPTP = new DataTable();
            da.Fill(dtPTP);
            return dtPTP;
        }

        public bool ThemPhieuThuePhong(DTO_PHIEUTHUEPHONG ptPhong)
        {
            CheckConnection();
            string sql = string.Format("INSERT INTO PHIEUTHUEPHONG(MAPHONG, NGAYLAP, SOLUONG, DONGIA, TINHTRANG) VALUES ('{0}', '{1}', '{2}', '{3}', N'Chưa thanh toán')", ptPhong._MAPHONG, ptPhong._NGAYLAP, ptPhong._SOLUONG, ptPhong._DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaPhieuThuePhong(DTO_PHIEUTHUEPHONG ptPhong)
        {
            CheckConnection();
            string sql = string.Format("UPDATE PHIEUTHUEPHONG SET MAPHONG = '{0}', NGAYLAP = '{1}', SOLUONG = '{2}', DONGIA = '{3}'", ptPhong._MAPHONG, ptPhong._NGAYLAP, ptPhong._SOLUONG, ptPhong._DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaPhieuThuePhong(string maPTP)
        {
            CheckConnection();
            string sql = string.Format("DELETE FROM PHIEUTHUEPHONG WHERE MAPTP = '{0}'", maPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaTinhTrangPTP(string maPTP)
        {
            CheckConnection();
            string sql = string.Format("UPDATE PHIEUTHUEPHONG SET TINHTRANG = N'Đã thanh toán' WHERE MAPTP = '{0}'", maPTP);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


    }
}
