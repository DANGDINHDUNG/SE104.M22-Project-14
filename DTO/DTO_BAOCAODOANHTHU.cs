using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BAOCAODOANHTHU
    {
        private int MABCDT;
        private string TENBAOCAO;
        private DateTime NGAYLAP;
        private int THANGBAOCAO;

        public int _MABCDT
        { get { return MABCDT; } set { MABCDT = value; } }

        public DateTime _NGAYLAP 
        { get { return NGAYLAP; } set { NGAYLAP = value; } }

        public int _THANGBAOCAO 
        { get { return THANGBAOCAO; } set { THANGBAOCAO = value;} }

        public string _TENBAOCAO 
        { get { return TENBAOCAO; } set { TENBAOCAO = value;} }

        public DTO_BAOCAODOANHTHU()
        {

        }

        public DTO_BAOCAODOANHTHU (int MABCDT, string TENBAOCAO, DateTime NGAYLAP, int THANGBAOCAO)
        {
            this.MABCDT = MABCDT;
            this.TENBAOCAO = TENBAOCAO;
            this.NGAYLAP = NGAYLAP;
            this.THANGBAOCAO = THANGBAOCAO;
        }


    }
}
