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
    public class DAL_BAOCAODOANHTHU : KetNoi
    {
        public DataTable getDSBAOCAODOANHTHU()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BAOCAODOANHTHU", connection);
            DataTable dtBAOCAODOANHTHU = new DataTable();
            da.Fill(dtBAOCAODOANHTHU);
            return dtBAOCAODOANHTHU;
        }

        public bool ThemBAOCAODOANHTHU(DTO_BAOCAODOANHTHU baoCaoDT)
        {
            connection.Open();
            string sql = string.Format("INSERT INTO BAOCAODOANHTHU(TENBAOCAO, NGAYLAP, THANGBAOCAO) VALUES ('{0}', '{1}', '{2}')", baoCaoDT._TENBAOCAO, baoCaoDT._NGAYLAP, baoCaoDT._THANGBAOCAO);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaBAOCAODOANHTHU(DTO_BAOCAODOANHTHU baoCaoDT)
        {
            connection.Open();
            string sql = string.Format("UPDATE BAOCAODOANHTHU SET TENBAOCAO = '{0}', NGAYLAP = '{1}', THANGBAOCAO = '{2}'", baoCaoDT._TENBAOCAO, baoCaoDT._NGAYLAP, baoCaoDT._THANGBAOCAO);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaBAOCAODOANHTHU(int maBCDT)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM BAOCAODOANHTHU WHERE MABCDT = '{0}')", maBCDT);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
