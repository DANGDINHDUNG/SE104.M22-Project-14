using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CHITIETHD
    {
        private int MACTHD;
        private int MAPTP;
        private int MAHD;
        private int MADV;
        private int SONGAYTHUE;

        public int _MACTHD { get { return MACTHD; } set { MACTHD = value; } }

        public int _MAPTP { get { return MAPTP; } set { MAPTP = value; } }   

        public int _MAHD { get { return MAHD; } set { MAHD = value; } }

        public int _MADV { get { return MADV; } set { MADV = value; } }

        public int _SONGAYTHUE { get { return SONGAYTHUE; } set { SONGAYTHUE = value; } }

        public DTO_CHITIETHD()
        {

        } 

        public DTO_CHITIETHD(int MACTHD, int MAPTP, int MAHD, int MADV, int SONGAYTHUE)
        {
            this.MACTHD = MACTHD;
            this.MAPTP = MAPTP;
            this.MAHD = MAHD;
            this.MADV = MADV;
            this.SONGAYTHUE = SONGAYTHUE; 
        }

    }
}
