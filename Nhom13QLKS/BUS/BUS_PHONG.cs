using System;
using DAL;
using DTO;
using System.Data;
using System.Collections.Generic;

namespace BUS
{
    public class BUS_PHONG
    {
        DAL_PHONG phong = new DAL_PHONG();

        public DataTable getDSPhong()
        {
            return phong.getDSPhong();
        }

        public bool ThemPhong(DTO_PHONG phongInput)
        {
            return phong.ThemPhong(phongInput);
        }

        public bool SuaPhong(DTO_PHONG phongInput, int maPhong)
        {
            return phong.SuaPhong(phongInput, maPhong);
        }

        public bool XoaPhong(int maPhong)
        {
            return phong.XoaPhong(maPhong);
        }

        public bool TimKiemPhong(int maPhong)
        {
            return phong.TimKiemPhong(maPhong);
        }

        public bool TimKiemPhongTheoTen(string tenPhong)
        {
            return phong.TimKiemPhongTheoTen(tenPhong);
        }
        
        public DataTable getDSPhongKemTrangThai()
        {
            return phong.getDSPhongKemTrangThai();
        }

        public List<string> TongHopMaPhong()
        {
            return phong.TongHopMaPhong();
        }

        public bool CheckPhongDaThue(int maPhong)
        {
            return phong.CheckPhongDaThue(maPhong);
        }

        public int TotalRoomsCount()
        {
            return phong.TotalRoomsCount();
        }

        public string GetDonGiaTheoMaPhong(string maPhong)
        {
            return phong.GetDonGiaTheoMaPhong(maPhong);
        }

        public DataTable getDSPhongTheoPTP(int maptp)
        {
            return phong.getDSPhongTheoPTP(maptp);
        }

        public bool SuaTrangThaiPhong(string trangthai, string maphong)
        {
            return phong.SuaTrangThaiPhong(trangthai, maphong);
        }


    }
}
