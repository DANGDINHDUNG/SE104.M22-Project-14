using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PHONG
    {
        private int MAPHONG;
        private string MALP;
        private string TENPHONG;
        private string GHICHU;
        private string TRANGTHAI;

        //Getter-Setter
        public int _MAPHONG
        {
            get { return MAPHONG; }
            set { MAPHONG = value; }
        }

        public string _MALP
        {
            get { return MALP; }
            set { MALP = value; }
        }
        public string _TENPHONG
        {
            get { return TENPHONG; }
            set { TENPHONG = value; }
        }

        public string _GHICHU
        {
            get { return GHICHU; }
            set { GHICHU = value; }
        }

        public string _TRANGTHAI
        {
            get { return TRANGTHAI; }
            set { TRANGTHAI = value; }
        }

        //Constructor

        public DTO_PHONG()
        {

        }

        public DTO_PHONG(int MAPHONG, string MALP, string TENPHONG, string GHICHU, string TRANGTHAI)
        {
            this.MAPHONG = MAPHONG;
            this.MALP = MALP;
            this.TENPHONG = TENPHONG;
            this.GHICHU = GHICHU;
            this.TRANGTHAI = TRANGTHAI;
        }
    }
}
