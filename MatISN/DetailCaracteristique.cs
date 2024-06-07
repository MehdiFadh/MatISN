using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class DetailCaracteristique
    {

        private Caracteristique uneCaracteristique;
        private string valeur;

		public string Valeur
		{
			get { return this.valeur; }
			set {this.valeur = value; }
		}

        public Caracteristique UneCaracteristique
        {
            get
            {
                return uneCaracteristique;
            }

            set
            {
                uneCaracteristique = value;
            }
        }
    }
}
