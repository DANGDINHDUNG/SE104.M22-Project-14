using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL;
namespace BUS
{
    public class BUS_LOAIKHACH
    {
        DAL_LOAIKHACH loaiKhach = new DAL_LOAIKHACH();
        public DataTable getLoaiKhach()
        {
            return loaiKhach.getLoaiKhach();
        }
        public bool ThemLoaiKhach(DTO_LOAIKHACH lk)
        {
            return loaiKhach.ThemLoaiKhach(lk);
        }
        public bool SuaLoaiKhach(DTO_LOAIKHACH lk)
        {
            return loaiKhach.SuaLoaiKhach(lk);
        }
        public bool XoaLoaiKhach(string malk)
        {
            return loaiKhach.XoaLoaiKhach(malk);
        }
    }
}
