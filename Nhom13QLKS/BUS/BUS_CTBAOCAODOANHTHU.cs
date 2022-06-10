using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_CTBAOCAODOANHTHU
    {
        DAL_CTBAOCAODOANHTHU chiTietBCDT = new DAL_CTBAOCAODOANHTHU();

        public DataTable getDSctBAOCAODOANHTHU(int mabcdt)
        {
            return chiTietBCDT.getDSCTBAOCAODOANHTHU(mabcdt);
        }

        public bool ThemCTBAOCAODOANHTHU(DTO_CTBAOCAODOANHTHU bcdt)
        {
            return chiTietBCDT.ThemCTBAOCAODOANHTHU(bcdt);
        }

        public bool SuaCTBAOCAODOANHTHUDT(int doanhthu, string malp, string mabcdt)
        {
            return chiTietBCDT.SuaCTBAOCAODOANHTHUDT(doanhthu, malp, mabcdt);
        }

        public bool SuaCTBAOCAODOANHTHUTL(double tyle, string malp, string mabcdt)
        {
            return chiTietBCDT.SuaCTBAOCAODOANHTHUTL(tyle, malp, mabcdt);
        }

        public bool XoaCTBAOCAODOANHTHU(int maCTBCDT)
        {
            return chiTietBCDT.XoaCTBAOCAODOANHTHU(maCTBCDT);
        }

        public bool KiemTraTonTaiCTBaoCao(string mabcdt)
        {
            return chiTietBCDT.KiemTraTonTaiCTBaoCao(mabcdt);
        }

        public string GetDoanhThu(string malp, string mabcdt)
        {
            return chiTietBCDT.GetDoanhThu(malp, mabcdt);
        }

        public string GetTongDoanhThuTrongThang(string mabcdt)
        {
            return chiTietBCDT.GetTongDoanhThuTrongThang(mabcdt);
        }



    }
}
