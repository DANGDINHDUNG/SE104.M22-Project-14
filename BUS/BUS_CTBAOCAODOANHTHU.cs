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

        public DataTable getDSctBAOCAODOANHTHU()
        {
            return chiTietBCDT.getDSCTBAOCAODOANHTHU();
        }

        public bool ThemCTBAOCAODOANHTHU(DTO_CTBAOCAODOANHTHU bcdt)
        {
            return chiTietBCDT.ThemCTBAOCAODOANHTHU(bcdt);
        }

        public bool SuaCTBAOCAODOANHTHU(DTO_CTBAOCAODOANHTHU bcdt)
        {
            return chiTietBCDT.SuaCTBAOCAODOANHTHU(bcdt);
        }

        public bool XoaCTBAOCAODOANHTHU(int maCTBCDT)
        {
            return chiTietBCDT.XoaCTBAOCAODOANHTHU(maCTBCDT);
        }
    }
}
