using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class Fournisseur : Table
    {
		private int numFournisseur;

		public int NumFournisseur
		{
			get { return this.numFournisseur; }
			set { this.numFournisseur = value; }
		}

		private string nomFournisseur;

		public string NomFournisseur
		{
			get { return this.nomFournisseur; }
			set { this.nomFournisseur = value; }
		}


	}
}
