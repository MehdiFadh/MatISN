using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MatISN
{
    public class Caserne
    {
        private static int ajoutCaserne;
        private int numCaserne;
        private string nom;
        private string ville;
        private string cp;
        private string rue;
        private string telephone;

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Ville
        {
            get
            {
                return ville;
            }

            set
            {
                ville = value;
            }
        }

        public string Cp
        {
            get
            {
                return cp;
            }

            set
            {
                cp = value;
            }
        }

        public string Rue
        {
            get
            {
                return rue;
            }

            set
            {
                rue = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }

            set
            {
                telephone = value;
            }
        }

        public int NumCaserne
        {
            get
            {
                return numCaserne;
            }

            set
            {
                numCaserne = value;
            }
        }

        public Caserne()
        {
            this.numCaserne = ajoutCaserne;
            ajoutCaserne++;
        }
        public Caserne(string nom)
        {
            Nom = nom;
            this.numCaserne = ajoutCaserne;
            ajoutCaserne++;
        }
    }
}
