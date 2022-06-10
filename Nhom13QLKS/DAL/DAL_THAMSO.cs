using System;
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
    public class DAL_THAMSO : KetNoi
    {
        public DataTable getTHAMSO()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM THAMSO", connection);
            DataTable dtTHAMSO = new DataTable();
            da.Fill(dtTHAMSO);
            return dtTHAMSO;
        }


        public bool SuaTHAMSO(double giatri, string mats)
        {
            CheckConnection();
            string sql = string.Format("UPDATE THAMSO SET GIATRI = '{0}' where MATHAMSO = '{1}'", giatri, mats);
            SqlCommand cmd = new SqlCommand(sql, connection);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else return false;
            connection.Close();
        }

        public int SoLuongToiDa()
        {
            string i;
            int soluong;
            string sql = string.Format("select GIATRI from THAMSO where MATHAMSO = 'TS1'");
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                i = dr[0].ToString();
            }
            soluong = Convert.ToInt32(dr[0].ToString());
            connection.Close();
            return soluong;
        }

        public int TylePhuThu()
        {
            string i;
            int tyle;
            string sql = string.Format("select GIATRI from THAMSO where MATHAMSO = 'TS3'");
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                i = dr[0].ToString();
            }
            tyle = Convert.ToInt32(dr[0].ToString());
            connection.Close();
            return tyle;
        }

        public double HeSoPhuThu()
        {
            string i;
            float heso;
            string sql = string.Format("select GIATRI from THAMSO where MATHAMSO = 'TS2'");
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                i = dr[0].ToString();
            }
            heso = float.Parse(dr[0].ToString());
            connection.Close();
            return heso;
        }

        public int KhuyenMai()
        {
            string i;
            int khuyenmai;
            string sql = string.Format("select GIATRI from THAMSO where MATHAMSO = 'TS5'");
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                i = dr[0].ToString();
            }
            khuyenmai = Convert.ToInt32(dr[0].ToString());
            connection.Close();
            return khuyenmai;
        }

        public int TienLe()
        {
            string i;
            int tienle;
            string sql = string.Format("select GIATRI from THAMSO where MATHAMSO = 'TS4'");
            SqlCommand com = new SqlCommand(sql, connection);
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                i = dr[0].ToString();
            }
            tienle = Convert.ToInt32(dr[0].ToString());
            connection.Close();
            return tienle;
        }
    }
}
