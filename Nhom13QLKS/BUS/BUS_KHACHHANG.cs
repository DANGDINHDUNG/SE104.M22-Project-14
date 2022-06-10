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
        public DataTable getKhachHang()
        {
            return khachHang.getKhachHang();
        }

        public DataTable getLoaiKhachHang()
        {
            return khachHang.getLoaiKhachHang();
        }
        public bool ThemKhachHang(DTO_KHACHHANG kh)
        {
            return khachHang.ThemKhachHang(kh);
        }

        public bool SuaKhachHang(DTO_KHACHHANG kh)
        {
            return khachHang.SuaKhachHang(kh);
        }

        public bool XoaKhachHang(int makh)
        {
            return khachHang.XoaKhachHang(makh);
        }

        public DataTable TimKiemKhachHang(string s)
        {
            return khachHang.TimKiemKhachHang(s);
        }

        public DataTable getKhachHangTrongPTP(int maptp)
        {
            return khachHang.getKhachHangTrongPTP(maptp);
        }
    }
}
