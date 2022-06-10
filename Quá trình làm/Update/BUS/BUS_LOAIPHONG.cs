using System;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_LOAIPHONG
    {
        DAL_LOAIPHONG loaiPhong = new DAL_LOAIPHONG();

        public DataTable getDSLoaiPhong()
        {
            return loaiPhong.getDSLoaiPhong();
        }

        public bool ThemLoaiPhong(DTO_LOAIPHONG loaiPhongInput)
        {
            return loaiPhong.ThemLoaiPhong(loaiPhongInput);
        }

        public bool SuaLoaiPhong(DTO_LOAIPHONG loaiPhongInput)
        {
            return loaiPhong.SuaLoaiPhong(loaiPhongInput);
        }

        public bool XoaLoaiPhong(string maLP)
        {
            return loaiPhong.XoaLoaiPhong(maLP);
        }

        public bool TimKiemTheoLoaiPhong(string maLP)
        {
            return loaiPhong.TimKiemTheoLoaiPhong(maLP);
        }
    }
}
