using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LOAIPHONG
    {
        private string MALP;
        private string TENLOAIPHONG;
        private decimal DONGIA;

        //Getter-Setter
        public string _MALP
        {
            get { return MALP; }
            set { MALP = value; }
        }

        public string _TENLOAIPHONG
        {
            get { return TENLOAIPHONG; }
            set { TENLOAIPHONG = value; }
        }
        public decimal _DONGIA
        {
            get { return DONGIA; }
            set { DONGIA = value; }
        }

        //Constructor

        public DTO_LOAIPHONG()
        {

        }

        public DTO_LOAIPHONG(string MALP, string TENLOAIPHONG, decimal DONGIA)
        {
            this.MALP = MALP;
            this.TENLOAIPHONG = TENLOAIPHONG;
            this.DONGIA = DONGIA;
        }
    }
}
