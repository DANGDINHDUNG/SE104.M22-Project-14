using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LOAIKHACH
    {
        int malk;
        string tenloaikhach;

        //Getter-Setter
        public int MALK
        {
            get { return malk; }
            set { malk = value; }
        }
        public string TENLOAIKHACH
        {
            get { return tenloaikhach; }
            set { tenloaikhach = value; }
        }

        //Constructor

       public DTO_LOAIKHACH()
       {

       }

        public DTO_LOAIKHACH(int malk,string tenloaikhach)
        {
            this.malk = malk;
            this.tenloaikhach = tenloaikhach;
        }
    }
}
