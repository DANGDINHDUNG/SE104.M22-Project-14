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
    public class BUS_THAMSO
    {
        DAL_THAMSO thamSo = new DAL_THAMSO();

        public DataTable getTHAMSO()
        {
            return thamSo.getTHAMSO();
        }

        public bool SuaTHAMSO(double giatri, string mats)
        {
            return thamSo.SuaTHAMSO(giatri, mats);
        }

        public int SoLuongToiDa()
        {
            return thamSo.SoLuongToiDa();
        } 

        public int TyLePhuThu()
        {
            return thamSo.TylePhuThu();
        } 

        public double HeSoPhuThu()
        {
            return thamSo.HeSoPhuThu();
        } 

        public int KhuyenMai()
        {
            return thamSo.KhuyenMai();
        } 

        public int TienLe()
        {
            return thamSo.TienLe();
        } 


    }
}
