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
    public class BUS_HOADON
    {
        DAL_HOADON hoaDon = new DAL_HOADON();

        public DataTable getHOADON()
        {
            return hoaDon.getHOADON();
        }

        public bool ThemHOADON(DTO_HOADON hd)
        {
            return hoaDon.ThemHOADON(hd);
        }

        public bool SuaHOADON(int tongtien, int mahd)
        {
            return hoaDon.SuaHOADON(tongtien, mahd);
        }

        public bool XoaHOADON(int maKH)
        {
            return hoaDon.XoaHOADON(maKH);
        }

        public string GetMaHD(string maPTP )
        {
            return hoaDon.GetMaHD(maPTP);
        }
    }
}
