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
        public DataTable getDSCTBAOCAODOANHTHU()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CTBAOCAODOANHTHU", connection);
            DataTable dtCTBAOCAODOANHTHU = new DataTable();
            da.Fill(dtCTBAOCAODOANHTHU);
            return dtCTBAOCAODOANHTHU;
        }

        public bool ThemCTBAOCAODOANHTHU(DTO_CTBAOCAODOANHTHU chiTietBCDT)
        {
            connection.Open();
            string sql = string.Format("INSERT INTO CTBAOCAODOANHTHU(MALP, MABCDT, DOANHTHU, TYLE) VALUES ('{0}', '{1}', '{2}', '{3}')", chiTietBCDT._MALP, chiTietBCDT._MABCDT, chiTietBCDT._DOANHTHU, chiTietBCDT._TYLE);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaCTBAOCAODOANHTHU(DTO_CTBAOCAODOANHTHU chiTietBCDT)
        {
            connection.Open();
            string sql = string.Format("UPDATE CTBAOCAODOANHTHU SET MALP = '{0}', MABCDT = '{1}', DOANHTHU = '{2}', TYLE = '{3}'", chiTietBCDT._MALP, chiTietBCDT._MABCDT, chiTietBCDT._DOANHTHU, chiTietBCDT._TYLE);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaCTBAOCAODOANHTHU(int maCTBCDT)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM CTBAOCAODOANHTHU WHERE MACTBCDT = '{0}')", maCTBCDT);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
