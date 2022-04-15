using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_DICHVU
    {
        private int madv;
        private string tendv;
        private int donggia;

        //Getter-Setter

        public int MADV
        {
            get { return madv; }
            set { madv = value; }
        }

        public string TENDV
        {
            get { return tendv; }
            set { tendv = value; }
        }

        public int DONGGIA
        {
            get { return donggia; }
            set { donggia = value; }
        }

        //Constructor

        public DTO_DICHVU()
        {

        }

        public DTO_DICHVU(int madv,string tendv,int donggia)
        {
            this.madv = madv;
            this.tendv = tendv;
            this.donggia = donggia;
        }
    }
}
