using System;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_CHITIETPTP
    {
        DAL_CHITIETPTP chiTietPTP = new DAL_CHITIETPTP();

        public DataTable getDSChiTietPTP()
        {
            return chiTietPTP.getDSChiTietPTP();
        }

        public bool ThemChiTietPTP(DTO_CHITIETPTP ptp)
        {
            return chiTietPTP.ThemChiTietPTP(ptp);
        }

        public bool SuaChiTietPTP(DTO_CHITIETPTP ptp)
        {
            return chiTietPTP.SuaChiTietPTP(ptp);
        }

        public bool XoaChiTietPTP(int maCTPTP)
        {
            return chiTietPTP.XoaChiTietPTP(maCTPTP);
        }

        /*public bool TimKiemChiTietPTP(int maCTPTP, string maKH)
        {
            return chiTietPTP.TimKiemChiTietPTP(maCTPTP, maKH);
        }*/
    }
}
