using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KHACHHANG
    {
        private int makh;
        private string malk;
        string tenkh;
        string cmnd;
        string diachi;

        //Getter-setter
        public int MAKH
        {
            get { return makh; }
            set { makh = value; }
        }

        public string MALK
        {
            get { return malk; }
            set { malk = value; }
        }

        public string TENKH
        {
            get { return tenkh; }
            set { tenkh = value; }
        }

        public string CMND
        {
            get { return cmnd; }
            set { cmnd = value; }
        }


        public string DIACHI
        {
            get { return diachi; }
            set { diachi = value; }
        }


        //Constructor

        public DTO_KHACHHANG()
        {

        }

        public DTO_KHACHHANG(int makh, string malk, string tenkh, string cmnd, string diachi)
        {
            this.makh = makh;
            this.malk = malk;
            this.tenkh = tenkh;
            this.cmnd = cmnd;
            this.diachi = diachi;
        }
    }
}
