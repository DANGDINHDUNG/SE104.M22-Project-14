using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DAL_CHITIETTHANHTOAN:KetNoi
    {
        public DataTable getCTThanhToan()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CHITIETTHANHTOAN", connection);
            DataTable dtCTTHANHTOAN = new DataTable();
            da.Fill(dtCTTHANHTOAN);
            return dtCTTHANHTOAN;
        }
        public bool ThemCTThanhToan(DTO_CHITIETTHANHTOAN cttt)
        {
            connection.Open();
            string sql = string.Format("INSERT INTO LOAIKHACH(MAHD,MAKH,MALHTT) VALUES ('{0}', '{1}','{2})",cttt.MAHD,cttt.MAKH,cttt.MALHTT );
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaCTThanhToan(DTO_CHITIETTHANHTOAN cttt)
        {
            connection.Open();
            string sql = string.Format("UPDATE CHITIETTHANHTOAN SET  MALHTT='{0}'",cttt.MALHTT);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaCTThanhToan(int mahd,int makh)
        {
            connection.Open();
            string sql = string.Format("DELETE FROM CHITIETTHANHTOAN WHERE MAHD = '{0}' AND MAKH='{1}')", mahd,makh);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }
    }
}
