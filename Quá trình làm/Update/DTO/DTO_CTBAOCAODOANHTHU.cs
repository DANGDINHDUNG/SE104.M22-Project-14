using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTBAOCAODOANHTHU
    {
        private int MACTBCDT;
        private string MALP;
        private int MABCDT;
        private long DOANHTHU;
        private float TYLE;

        public int _MACTBCDT
        {
            get { return MACTBCDT; }
            set { MACTBCDT = value; }
        }

        public string _MALP
        {
            get { return MALP; }
            set { MALP = value; }   
        }

        public int _MABCDT
        {
            get { return MABCDT; }
            set { MABCDT= value; }
        }

        public long _DOANHTHU
        {
            get { return DOANHTHU; }
            set { DOANHTHU= value; }    
        }

        public float _TYLE
        {
            get { return TYLE; }    
            set { TYLE= value; }    
        }

        public DTO_CTBAOCAODOANHTHU()
        {

        }

        public DTO_CTBAOCAODOANHTHU(int MACTBCDT, string MALP, int MABCDT, long DOANHTHU, float TYLE)
        {
            this.MACTBCDT = MACTBCDT;
            this.MALP = MALP;
            this.MABCDT = MABCDT;
            this.DOANHTHU = DOANHTHU;
            this.TYLE = TYLE;
        }
    }
}
