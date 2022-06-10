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

        public bool ThemChiTietPTP(string maPTP, string maKH)
        {
            return chiTietPTP.ThemChiTietPTP(maPTP, maKH);
        }

        public bool SuaChiTietPTP(DTO_CHITIETPTP ptp)
        {
            return chiTietPTP.SuaChiTietPTP(ptp);
        }

        public bool XoaChiTietPTP(string maPTP)
        {
            return chiTietPTP.XoaChiTietPTP(maPTP);
        }
    }
}
