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
        private int SONGAYHUE;

        public int _MACTHD { get { return MACTHD; } set { MACTHD = value; } }

        public int _MAPTP { get { return MAPTP; } set { MAPTP = value; } }   

        public int _MAHD { get { return MAHD; } set { MAHD = value; } }

        private int _MADV { get { return MADV; } set { MADV = value; } }

        public int _SONGAYHUE { get { return SONGAYHUE; } set { SONGAYHUE = value; } }

        public DTO_CHITIETHD()
        {

        }

        public DTO_CHITIETHD(int MACTHD)
    }
}
