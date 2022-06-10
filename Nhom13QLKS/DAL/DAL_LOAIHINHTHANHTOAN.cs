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
    public class DAL_LOAIHINHTHANHTOAN : KetNoi
    {
        public DataTable getDSLoaiHinhTT()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LOAIHINHTHANHTOAN", connection);
            DataTable dtLoaiHinhTT = new DataTable();
            da.Fill(dtLoaiHinhTT);
            return dtLoaiHinhTT;
        }

        public bool ThemLoaiHinhTT(DTO_LOAIHINHTHANHTOAN loaiHinhTT)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("NSERT INTO LOAIHINHTHANHTOAN(MALHTT, TENLHTT) VALUES ('{0}', '{1}')", loaiHinhTT._MALHTT, loaiHinhTT._TENLHTT);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool SuaLoaiHinhTT(DTO_LOAIHINHTHANHTOAN loaiHinhTT)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("UPDATE LOAIHINHTHANHTOAN SET TENLHTT = '{0}' WHERE MALHTT = '{1}'", loaiHinhTT._TENLHTT, loaiHinhTT._MALHTT);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public bool XoaLoaiHinhTT(int maLHTT)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("DELETE FROM LOAIHINHTHANHTOAN WHERE MALHTT = '{0}')", maLHTT);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public List<string> NhungLoaiHinhThanhToan()
        {
            List<string> listThanhToan = new List<string>();
            if (connection.State != ConnectionState.Open)
                connection.Open();
            string sql = string.Format("SELECT TENLHTT FROM LOAIHINHTHANHTOAN");
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                listThanhToan.Add(reader[0].ToString());
            }
            connection.Close();
            return listThanhToan;
        }
    }
}
