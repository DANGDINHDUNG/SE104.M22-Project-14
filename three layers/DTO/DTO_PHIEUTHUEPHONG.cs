using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_PHIEUTHUEPHONG
    {
        private int MAPTP;
        private int MAPHONG;
        private DateTime NGAYLAP;
        private int SOLUONG;

        //Getter-Setter
        public int _MAPTP
        {
            get { return MAPTP; }
            set { MAPTP = value; }
        }

        public int _MAPHONG
        {
            get { return MAPHONG; }
            set { MAPHONG = value; }
        }
        public DateTime _NGAYLAP
        {
            get { return NGAYLAP; }
            set { NGAYLAP = value; }
        }
        public int _SOLUONG
        {
            get { return SOLUONG; }
            set { SOLUONG = value; }
        }

        //Constructor

        public DTO_PHIEUTHUEPHONG()
        {

        }

        public DTO_PHIEUTHUEPHONG(int MAPTP, int MAPHONG, DateTime NGAYLAP, int SOLUONG)
        {
            this.MAPTP = MAPTP;
            this.MAPHONG = MAPHONG;
            this.NGAYLAP = NGAYLAP;
            this.SOLUONG = SOLUONG;
        }
    }
}
