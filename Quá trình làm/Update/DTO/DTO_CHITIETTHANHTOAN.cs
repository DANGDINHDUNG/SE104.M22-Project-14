using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CHITIETTHANHTOAN
    {
        private int mahd;
        private int makh;
        private int malhtt;

        //Getter-Setter
        public int MAHD
        {
            get { return mahd; }
            set { mahd = value; }
        }

        public int MAKH
        {
            get { return makh; }
            set { makh = value; }
        }

        public int MALHTT
        {
            get { return malhtt; }
            set { malhtt = value; }
        }

        //Constructor

        public DTO_CHITIETTHANHTOAN()
        {

        }

        public DTO_CHITIETTHANHTOAN(int mahd,int makh,int malhtt)
        {
            this.mahd = mahd;
            this.makh = makh;
            this.malhtt = malhtt;
        }
    }
}
