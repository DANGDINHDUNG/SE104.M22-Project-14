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
    public class DAL_CTBAOCAODOANHTHU : KetNoi
    {
        public DataTable getDSCTBAOCAODOANHTHU(int mabcdt)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CTBAOCAODOANHTHU where MABCDT = '" + mabcdt + "'", connection);
            DataTable dtCTBAOCAODOANHTHU = new DataTable();
            da.Fill(dtCTBAOCAODOANHTHU);
            return dtCTBAOCAODOANHTHU;
        }

        public bool ThemCTBAOCAODOANHTHU(DTO_CTBAOCAODOANHTHU chiTietBCDT)
        {
            CheckConnection();
            string sql = string.Format("INSERT INTO CTBAOCAODOANHTHU(MALP, MABCDT, DOANHTHU, TYLE) VALUES ('{0}', '{1}', '{2}', '{3}')", chiTietBCDT._MALP, chiTietBCDT._MABCDT, chiTietBCDT._DOANHTHU, chiTietBCDT._TYLE);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaCTBAOCAODOANHTHUDT(int doanhthu, string malp, string mabcdt)
        {
            CheckConnection();
            string sql = string.Format("UPDATE CTBAOCAODOANHTHU SET DOANHTHU = '{0}'" +
                                       "where MALP = '{1}' and MABCDT = '{2}'", doanhthu, malp, mabcdt);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaCTBAOCAODOANHTHUTL(double tyle, string malp, string mabcdt)
        {
            CheckConnection();
            string sql = string.Format("UPDATE CTBAOCAODOANHTHU SET TYLE = '{0}' " +
                                       "where MALP = '{1}' and MABCDT = '{2}'", tyle, malp, mabcdt);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaCTBAOCAODOANHTHU(int maCTBCDT)
        {
            CheckConnection();
            string sql = string.Format("DELETE FROM CTBAOCAODOANHTHU WHERE MACTBCDT = '{0}')", maCTBCDT);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool KiemTraTonTaiCTBaoCao(string mabcdt)
        {
            bool flag = false;
            string sql = string.Format("select MALP from CTBAOCAODOANHTHU where MABCDT = '{0}'", mabcdt);
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                flag = true;
            }
            connection.Close();
            return flag;
        }

        public string GetDoanhThu(string malp, string mabcdt)
        {
            string doanhthu = string.Empty;
            string sql = string.Format("select DOANHTHU from CTBAOCAODOANHTHU where MALP = '{0}' and MABCDT = '{1}'", malp, mabcdt);
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                doanhthu = dr[0].ToString();
            }
            connection.Close();
            return doanhthu;
        }

        public string GetTongDoanhThuTrongThang(string mabcdt)
        {
            string tongdoanhthu = string.Empty;
            string sql = string.Format("select sum(DOANHTHU) from CTBAOCAODOANHTHU where MABCDT = '{0}'", mabcdt);
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                tongdoanhthu = dr[0].ToString();
            }
            connection.Close();
            return tongdoanhthu;
        }
    }
}
