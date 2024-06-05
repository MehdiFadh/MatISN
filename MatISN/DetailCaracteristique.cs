using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class DetailCaracteristique : Table
    {

		private int numMateriel;

		public int NumMateriel
        {
			get { return this.numMateriel; }
			set { this.numMateriel = value; }
		}


		private int numCaracteristique;

		public int NumCaracteristique
		{
			get { return numCaracteristique; }
			set { numCaracteristique = value; }
		}

		private string valeur;

		public string Valeur
		{
			get { return this.valeur; }
			set {this.valeur = value; }
		}


	}
}
