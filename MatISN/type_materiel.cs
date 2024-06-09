using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class type_materiel
    {
        private static int ajoutTypeMateriel;
        private int codeType;

        public int CodeType
        {
            get
            {
                return codeType;
            }

            set
            {
                codeType = value;
            }
        }

        public type_materiel()
        {
            this.CodeType = ajoutTypeMateriel;
            ajoutTypeMateriel++;
        }
    }
}
