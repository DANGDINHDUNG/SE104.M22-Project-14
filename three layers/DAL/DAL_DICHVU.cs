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
            connection.Open();
            string sql = string.Format("NSERT INTO DICHVU(TENDV,DONGGIA) VALUES ('{0}', '{1}')", dv.TENDV,dv.DONGGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaDichVu(DTO_DICHVU dv)
        {
            connection.Open();
            string sql = string.Format("UPDATE DICHVU SET TENDV='{0}', DONGGIA='{1}'", dv.TENDV,dv.DONGGIA);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaDichVu(int madv)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM DICHVU WHERE MADV = '{0}')", madv);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
