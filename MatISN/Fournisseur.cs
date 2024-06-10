using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class Fournisseur
    {
		private static int ajoutFournisseur;

        private int numFournisseur;

        private string nomFournisseur;

		public string NomFournisseur
		{
			get { return this.nomFournisseur; }
			set { this.nomFournisseur = value; }
		}

        public int NumFournisseur
        {
            get
            {
                return numFournisseur;
            }

            set
            {
                numFournisseur = value;
            }
        }

        public Fournisseur()
		{
            this.NumFournisseur = ajoutFournisseur;
            ajoutFournisseur++;


        }
        public Fournisseur(string nomFournisseur)
        {
            NomFournisseur = nomFournisseur;
            this.NumFournisseur = ajoutFournisseur;
            ajoutFournisseur++;
        }


    }
}
