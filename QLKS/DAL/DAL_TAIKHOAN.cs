using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DAL_TAIKHOAN:KetNoi
    {
        public DataTable getTaiKhoan()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TAIKHOAN", connection);
            DataTable dtTAIKHOAN = new DataTable();
            da.Fill(dtTAIKHOAN);
            return dtTAIKHOAN;
        }
        public bool ThemTaikhoan(DTO_TAIKHOAN tk)
        {
            connection.Open();
            string sql= string.Format("NSERT INTO TAIKOHAN(TENCHUTAIKHOAN, TENDANGNHAP, MATKHAU,QUYENHAN) VALUES ('{0}', '{1}', '{2}','{3}')",tk._TENCHUTAIKHOAN,tk._TENDANGNHAP,tk._MATKHAU,tk._QUYENHAN );
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaTaiKhoan(DTO_TAIKHOAN tk)
        {
            connection.Open();
            string sql = string.Format("UPDATE TAIKHOAN SET TENCHUTAIKHOAN='{0}', TENDANGNHAP='{1}', MATKHAU='{2}',QUYENHAN='{3}'", tk._TENCHUTAIKHOAN, tk._TENDANGNHAP, tk._MATKHAU, tk._QUYENHAN);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaTaiKhoan(int matk)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM TAIKHOAN WHERE MATK = '{0}')", matk);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool KiemTraTaiKhoan(string tenchutaikhoan,string matkhau)
        {
            connection.Open();
            string sql = string.Format("SELECT * FROM TAIKHOAN WHERE TENCHUTAIKHOAN='{0}' AND MATKHAU='{1}'",tenchutaikhoan,matkhau);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
