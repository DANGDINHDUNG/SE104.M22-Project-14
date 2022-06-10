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
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("INSERT INTO BAOCAODOANHTHU(TENBAOCAO, NGAYLAP, THANGBAOCAO, NAMBAOCAO) VALUES (N'{0}', '{1}', '{2}', '{3}')", baoCaoDT._TENBAOCAO, baoCaoDT._NGAYLAP, baoCaoDT._THANGBAOCAO, baoCaoDT._NAMBAOCAO);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }


        public bool SuaBAOCAODOANHTHU(DTO_BAOCAODOANHTHU baoCaoDT)
        {
            if (connection.State != ConnectionState.Open)
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
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM BAOCAODOANHTHU WHERE MABCDT = '{0}')", maBCDT);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool KiemTraTonTaiBaoCao(int thangbc, int nambc)
        {
            bool flag = false;
            string sql = string.Format("select MABCDT from BAOCAODOANHTHU where THANGBAOCAO = '{0}' and NAMBAOCAO = '{1}'", thangbc, nambc);
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

        public string GetMaBCDT(int thangbc, int nambc)
        {
            string code = string.Empty;
            string sql = string.Format("select MABCDT from BAOCAODOANHTHU where THANGBAOCAO = '{0}' and NAMBAOCAO = '{1}'", thangbc, nambc);
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
