using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_THAMSO
    {
        private string mats;
        private string tenthamso;
        private int giatri;

        //Getter-setter
        public string MATS
        {
            get { return mats; }
            set { mats = value; }
        }

        public string TENTHAMSO
        {
            get { return tenthamso; }
            set { tenthamso = value; }
        }
        public int GIATRI
        {
            get { return giatri; }
            set { giatri = value; }
        }

        //Constructor

        public DTO_THAMSO()
        {

        }

        public DTO_THAMSO(string mats, string tenthamso, int giatri)
        {
            this.mats = mats;
            this.tenthamso = tenthamso;
            this.giatri = giatri;
        }
    }
}
