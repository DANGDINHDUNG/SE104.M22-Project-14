using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HOADON
    {
        private int MAHD;
        private string MAKH;
        private DateTime NGAYLAP;
        private long TONGTIEN;
        
        public int _MAHD 
        { get { return MAHD; } set { MAHD = value; } }

        public string _MAKH 
        { get { return MAKH; } set { MAKH = value; } }
        
        public DateTime _NGAYLAP 
        { get { return NGAYLAP; } set { NGAYLAP = value; } }

        public long _TONGTIEN 
        { get { return TONGTIEN; } set { TONGTIEN = value; } }

        public DTO_HOADON()
        {

        }

        public DTO_HOADON (int MAHD, string MAKH, DateTime NGAYLAP, long TONGTIEN)
        {
            this.MAHD = MAHD;
            this.MAKH = MAKH;
            this.NGAYLAP = NGAYLAP;
            this.TONGTIEN = TONGTIEN;
        }
    }
}
