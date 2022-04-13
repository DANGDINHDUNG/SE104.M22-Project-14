using System;

namespace DTO
{
    public class DTO_TAIKHOAN
    {
        private int MATK;
        private string TENCHUTAIKHOAN;
        private string TENDANGNHAP;
        private string MATKHAU;
        private string QUYENHAN;

        //Getter-Setter
        public int _MATK
        {
            get { return MATK; }
            set { MATK = value; }
        }

        public string _TENCHUTAIKHOAN
        {
            get { return TENCHUTAIKHOAN; }
            set { TENCHUTAIKHOAN = value; }
        }

        public string _TENDANGNHAP
        {
            get { return TENDANGNHAP; }
            set { TENDANGNHAP = value; }
        }

        public string _MATKHAU
        {
            get { return MATKHAU; }
            set { MATKHAU = value; }
        }

        public string _QUYENHAN
        {
            get { return QUYENHAN; }
            set { QUYENHAN = value; }
        }

        //Constructor

        DTO_TAIKHOAN()
        {

        }

        DTO_TAIKHOAN(int MATK,string TENCHUTAIKHOAN,string TENDANGNHAP,string MATKHAU,string QUYENHAN)
        {
            this.MATK = MATK;
            this.TENCHUTAIKHOAN = TENCHUTAIKHOAN;
            this.TENDANGNHAP = TENDANGNHAP;
            this.MATKHAU = MATKHAU;
            this.QUYENHAN = QUYENHAN;
        }
    }
}
