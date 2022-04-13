using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTO_KHACHHANG
    {
        private string makh;
        private string malk;
        string hoten;
        string cmnd_cccd;
        string sdt;
        string gioitinh;
        int tuoi;

        //Getter-setter
        public string MAKH
        {
            get { return makh; }
            set { makh = value; }
        }

        public string MALK
        {
            get { return malk; }
            set { malk = value; }
        }

        public string HOTEN
        {
            get { return hoten; }
            set { hoten = value; }
        }

        public string CMND
        {
            get { return cmnd_cccd; }
            set { cmnd_cccd = value; }
        }

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string GIOITINH
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        public int TUOI
        {
            get { return tuoi; }
            set { tuoi = value; }
        }

        //Constructor

        public DTO_KHACHHANG()
        {

        }

        public DTO_KHACHHANG(string makh,string malk,string hoten,string cmnd_cccd,string sdt,string gioitinh,int tuoi)
        {
            this.makh = makh;
            this.malk = malk;
            this.hoten = hoten;
            this.cmnd_cccd = cmnd_cccd;
            this.sdt = sdt;
            this.gioitinh = gioitinh;
            this.tuoi = tuoi;
        }
    }
}
