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
    public class BUS_CHITIETHD
    {
        DAL_CHITIETHD chitietHD = new DAL_CHITIETHD();

        public DataTable getDSCHITIETHD()
        {
            return chitietHD.getDSCHITIETHD();
        }

        public bool ThemCHITIETHD(DTO_CHITIETHD cthd)
        {
            return chitietHD.ThemCHITIETHD(cthd);
        }

        public bool SuaCHITIETHD(DTO_CHITIETHD cthd)
        {
            return chitietHD.SuaCHITIETHD(cthd);
        }

        public bool XoaCHITIETHD(int maCTHD)
        {
            return chitietHD.XoaCHITIETHD(maCTHD);
        }
    }
}
