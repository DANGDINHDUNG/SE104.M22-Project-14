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

        public bool SuaHOADON(DTO_HOADON hd)
        {
            return hoaDon.SuaHOADON(hd);
        }

        public bool XoaHOADON(int maKH)
        {
            return hoaDon.XoaHOADON(maKH);
        }
    }
}
