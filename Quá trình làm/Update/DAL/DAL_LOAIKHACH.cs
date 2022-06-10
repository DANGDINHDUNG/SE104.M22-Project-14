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
    public class DAL_LOAIKHACH:KetNoi
    {
        public DataTable getLoaiKhach()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LOAIKHACH", connection);
            DataTable dtLOAIKHACH = new DataTable();
            da.Fill(dtLOAIKHACH);
            return dtLOAIKHACH;
        }
        public bool ThemLoaiKhach(DTO_LOAIKHACH lk)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("INSERT INTO LOAIKHACH(MALK,TENLOAIKHACH) VALUES ('{0}', N'{1}' WHERE MALK = '{2}'", lk.MALK,lk.TENLOAIKHACH, lk.MALK);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaLoaiKhach(DTO_LOAIKHACH lk)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("UPDATE LOAIKHACH SET  TENLOAIKHACH=N'{0}'",lk.TENLOAIKHACH);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaLoaiKhach(string malk)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM LOAIKHACH WHERE MALK = '{0}'", malk);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
