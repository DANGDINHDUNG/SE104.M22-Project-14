using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CHITIETPTP
    {
        private int MACTPTP;
        private int MAPTP;
        private string MAKH;

        //Getter-Setter
        public int _MACTPTP
        {
            get { return MACTPTP; }
            set { MACTPTP = value; }
        }

        public int _MAPTP
        {
            get { return MAPTP; }
            set { MAPTP = value; }
        }
        public string _MAKH
        {
            get { return MAKH; }
            set { MAKH = value; }
        }

        //Constructor

        public DTO_CHITIETPTP()
        {

        }

        public DTO_CHITIETPTP(int MACTPTP, int MAPTP, string MAKH)
        {
            this.MACTPTP = MACTPTP;
            this.MAPTP = MAPTP;
            this.MAKH = MAKH;
        }
    }
}
