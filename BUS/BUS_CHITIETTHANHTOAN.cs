using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
namespace BUS
{
    public class BUS_CHITIETTHANHTOAN
    {
        DAL_CHITIETTHANHTOAN ctThanhToan = new DAL_CHITIETTHANHTOAN();

        public DataTable getCTThanhToan()
        {
            return ctThanhToan.getCTThanhToan();
        }

        public bool ThemCTThanhToan(DTO_CHITIETTHANHTOAN cttt)
        {
            return ctThanhToan.ThemCTThanhToan(cttt);
        }

        public bool SuaCTThanhToan(DTO_CHITIETTHANHTOAN cttt)
        {
            return ctThanhToan.SuaCTThanhToan(cttt);
        }

        public bool XoaCTThanhToan(int mahd,int makh)
        {
            return ctThanhToan.XoaCTThanhToan(mahd, makh);
        }
    }
}
