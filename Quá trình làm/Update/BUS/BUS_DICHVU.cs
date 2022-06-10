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
    public class BUS_DICHVU
    {
        DAL_DICHVU dichVu = new DAL_DICHVU();

        public DataTable getDichVu()
        {
            return dichVu.getDichVu();
        }
        public bool ThemDichVu(DTO_DICHVU dv)
        {
            return dichVu.ThemDichVu(dv);
        }
        public bool SuaDichVu(DTO_DICHVU dv)
        {
            return dichVu.SuaDichVu(dv);
        }
        public bool XoaDichVu(int madv)
        {
            return dichVu.XoaDichVu(madv);
        }
    }
}
