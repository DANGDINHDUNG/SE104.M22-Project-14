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
    public class DAL_PHANLOAITK:KetNoi
    {
        public DataTable getPhanLoaiTK()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM PHANLOAITAIKHOAN", connection);
            DataTable dtPHANLOAITK = new DataTable();
            da.Fill(dtPHANLOAITK);
            return dtPHANLOAITK;
        }
        public bool ThemPhanLoaiTK(DTO_PHANLOAITK pltk)
        {
            connection.Open();
            string sql = string.Format("NSERT INTO PHANLOAITAIKHOAN(TENLOAITAIKHOAN,QUYENHAN) VALUES ('{0}', '{1}')", pltk.TENLOAITK,pltk.QUYENHAN);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaPhanLoaiTK(DTO_PHANLOAITK pltk)
        {
            connection.Open();
            string sql = string.Format("UPDATE PHANLOAITAIKHOAN SET TENLOAITAIKHOAN='{0}, QUYENHAN='{1}'",pltk.TENLOAITK,pltk.QUYENHAN);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaPhanLoaiTK(int maltk)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM PHANLOAITAIKHOAN WHERE MALOAITK = '{0}')", maltk);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
