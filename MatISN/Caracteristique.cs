using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class Caracteristique : Table
    {
        string nom;



        public override int Create()
        {
            Sql = "";
            return base.Create();
        }

        public override int Delete()
        {
            Sql = "";
            return base.Delete();
        }

        public override int Update()
        {
            Sql = "";
            return base.Update();
        }


    }
}
