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
    public class BUS_BAOCAODOANHTHU
    {
        DAL_BAOCAODOANHTHU baoCaoDT = new DAL_BAOCAODOANHTHU();

        public DataTable getDSBAOCAODOANHTHU()
        {
            return baoCaoDT.getDSBAOCAODOANHTHU();
        }

        public bool ThemBAOCAODOANHTHU(DTO_BAOCAODOANHTHU bcdt)
        {
            return baoCaoDT.ThemBAOCAODOANHTHU(bcdt);
        }

        public bool SuaBAOCAODOANHTHU(DTO_BAOCAODOANHTHU bcdt)
        {
            return baoCaoDT.SuaBAOCAODOANHTHU(bcdt);
        }

        public bool XoaBAOCAODOANHTHU(int maBCDT)
        {
            return baoCaoDT.XoaBAOCAODOANHTHU(maBCDT);
        }
    }
}
