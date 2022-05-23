using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LOAIHINHTHANHTOAN
    {
        private int MALHTT;
        private string TENLHTT;

        //Getter-Setter
        public int _MALHTT
        {
            get { return MALHTT; }
            set { MALHTT = value; }
        }

        public string _TENLHTT
        {
            get { return TENLHTT; }
            set { TENLHTT = value; }
        }

        //Constructor

        public DTO_LOAIHINHTHANHTOAN()
        {

        }

        public DTO_LOAIHINHTHANHTOAN(int MALHTT, string TENLHTT)
        {
            this.MALHTT = MALHTT;
            this.TENLHTT = TENLHTT;
        }
    }
}
