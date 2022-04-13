using System;
using DAL;
using DTO;
using System.Data;
namespace BUS
{
    public class BUS_TAIKHOAN
    {
        DAL_TAIKHOAN taikhoan = new DAL_TAIKHOAN();

        public DataTable getTaiKhoan()
        {
            return taikhoan.getTaiKhoan();
        }

        public bool ThemTaiKhoan(DTO_TAIKHOAN tk)
        {
            return taikhoan.ThemTaikhoan(tk);
        }

        public bool SuaTaiKhoan(DTO_TAIKHOAN tk)
        {
            return taikhoan.SuaTaiKhoan(tk);
        }

        public bool XoaTaiKhoan(int matk)
        {
            return taikhoan.XoaTaiKhoan(matk);
        }

        public bool KiemTraTaiKhoan(string tendangnhap,string matkhau)
        {
            return taikhoan.KiemTraTaiKhoan(tendangnhap, matkhau);
        }

    }
}
