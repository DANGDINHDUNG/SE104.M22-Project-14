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
            Hash256 h = new Hash256();
            SHA256 sha256Hash = SHA256.Create();
            string hash = h.GetHash(sha256Hash, tk._MATKHAU);
            string sql= string.Format("NSERT INTO TAIKHOAN(MALOAITK,TENCHUTAIKHOAN, TENDANGNHAP, MATKHAU) VALUES ('{0}', '{1}', '{2}','{3}')",tk._MALOAITK,tk._TENCHUTAIKHOAN,tk._TENDANGNHAP,hash );
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaTaiKhoan(DTO_TAIKHOAN tk)
        {
            connection.Open();
            Hash256 h = new Hash256();
            SHA256 sha256Hash = SHA256.Create();
            string hash = h.GetHash(sha256Hash, tk._MATKHAU);
            string sql = string.Format("UPDATE TAIKHOAN SET MALOAITK='{0}', TENCHUTAIKHOAN='{1}', TENDANGNHAP='{2}', MATKHAU='{3}'",tk._MALOAITK, tk._TENCHUTAIKHOAN, tk._TENDANGNHAP, hash);
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
            Hash256 h = new Hash256();
            SHA256 sha256Hash = SHA256.Create();
            string hash = h.GetHash(sha256Hash, matkhau);
            string sql = string.Format("SELECT * FROM TAIKHOAN WHERE TENCHUTAIKHOAN='{0}' AND MATKHAU='{1}'",tenchutaikhoan,hash);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
