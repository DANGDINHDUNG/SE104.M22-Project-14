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
    public class BUS_LOAIHINHTHANHTOAN
    {

        DAL_LOAIHINHTHANHTOAN loaiHinhTT = new DAL_LOAIHINHTHANHTOAN();

        public DataTable getDSLoaiHinhTT()
        {
            return loaiHinhTT.getDSLoaiHinhTT();
        }

        public bool ThemLoaiHinhTT(DTO_LOAIHINHTHANHTOAN loaiHinhTTInput)
        {
            return loaiHinhTT.ThemLoaiHinhTT(loaiHinhTTInput);
        }

        public bool SuaLoaiHinhTT(DTO_LOAIHINHTHANHTOAN loaiHinhTTInput)
        {
            return loaiHinhTT.SuaLoaiHinhTT(loaiHinhTTInput);
        }

        public bool XoaLoaiHinhTT(int maLHTT)
        {
            return loaiHinhTT.XoaLoaiHinhTT(maLHTT);
        }

        public List<string> NhungLoaiHinhThanhToan()
        {
            return loaiHinhTT.NhungLoaiHinhThanhToan();
        }
    }
}
