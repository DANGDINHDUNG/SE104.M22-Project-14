using System;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    internal class BUS_PHIEUTHUEPHONG
    {
        DAL_PHIEUTHUEPHONG ptPhong = new DAL_PHIEUTHUEPHONG();

        public DataTable getDSPTP()
        {
            return ptPhong.getDSPTP();
        }

        public bool ThemPhieuThuePhong(DTO_PHIEUTHUEPHONG ptPhongInput)
        {
            return ptPhong.ThemPhieuThuePhong(ptPhongInput);
        }

        public bool SuaPhieuThuePhong(DTO_PHIEUTHUEPHONG ptPhongInput)
        {
            return ptPhong.SuaPhieuThuePhong(ptPhongInput);
        }

        public bool XoaPhieuThuePhong(string maPTP)
        {
            return ptPhong.XoaPhieuThuePhong(maPTP);
        }

        /*public bool TimKiemTheoLoaiPhong(string maLP)
        {
            return loaiPhong.TimKiemTheoLoaiPhong(maLP);
        }*/
    }
}
