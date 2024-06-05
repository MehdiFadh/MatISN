using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MatISN
{
    public class Caserne : Table
    {
        string nom;
        string ville;
        string cp;
        string rue;
        string telephone; 
       
      
      



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
