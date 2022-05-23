using System;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_PHONG
    {
        DAL_PHONG phong = new DAL_PHONG();

        public DataTable getDSPhong()
        {
            return phong.getDSPhong();
        }

        public bool ThemPhong(DTO_PHONG phongInput)
        {
            return phong.ThemPhong(phongInput);
        }

        public bool SuaPhong(DTO_PHONG phongInput)
        {
            return phong.SuaPhong(phongInput);
        }

        public bool XoaPhong(int maPhong)
        {
            return phong.XoaPhong(maPhong);
        }

        public bool TimKiemPhong(int maPhong, string maLP)
        {
            return phong.TimKiemPhong(maPhong);
        }
    }
}
