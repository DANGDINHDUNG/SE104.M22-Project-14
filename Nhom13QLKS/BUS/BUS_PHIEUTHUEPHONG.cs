using System;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_PHIEUTHUEPHONG
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

        public DataTable getDSPTPKemKhachHang()
        {
            return ptPhong.getDSPTPKemKhachHang();
        }

        /*public bool TimKiemTheoLoaiPhong(string maLP)
        {
            return loaiPhong.TimKiemTheoLoaiPhong(maLP);
        }*/

        public bool SuaTinhTrangPTP(string maptp)
        {
            return ptPhong.SuaTinhTrangPTP(maptp);
        }
    }
}
