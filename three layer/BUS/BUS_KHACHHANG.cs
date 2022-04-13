using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class BUS_KHACHHANG
    {
        DAL_KHACHHANG khachHang = new DAL_KHACHHANG();
        public DataTable getTaiKhoan()
        {
            return khachHang.getTaiKhoan();
        }
        public bool ThemKhachHang(DTO_KHACHHANG kh)
        {
            return khachHang.ThemKhachHang(kh);
        }

        public bool SuaKhachHang(DTO_KHACHHANG kh)
        {
            return khachHang.SuaKhachHang(kh);
        }

        public bool XoaKhachHang(string makh)
        {
            return khachHang.XoaKhachHang(makh);
        }

        public bool TimKiemKhachHang(string s)
        {
            return khachHang.TimKiemKhachHang(s);
        }
    }
}
