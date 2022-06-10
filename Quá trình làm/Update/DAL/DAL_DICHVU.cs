using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAL
{
    public class DAL_DICHVU:KetNoi
    {
        public DataTable getDichVu()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DICHVU", connection);
            DataTable dtDICHVU = new DataTable();
            da.Fill(dtDICHVU);
            return dtDICHVU;
        }
        public bool ThemDichVu(DTO_DICHVU dv)
        {

            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("INSERT INTO DICHVU(TENDV,DONGIA) VALUES (N'{0}', '{1}')", dv.TENDV,dv.DONGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaDichVu(DTO_DICHVU dv)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("UPDATE DICHVU SET TENDV=N'{0}', DONGIA='{1}'Where MADV='{2}'", dv.TENDV,dv.DONGIA,dv.MADV);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaDichVu(int madv)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM DICHVU WHERE MADV = '{0}'", madv);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
