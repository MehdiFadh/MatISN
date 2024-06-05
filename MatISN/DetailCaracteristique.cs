using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    internal class DetailCaracteristique
    {

		private int numMateriel;

		public int NumMateriel
        {
			get { return this.numMateriel; }
			set { if(value == null)
				{
					throw new ArgumentNullException("Le numéro matériel est nul");
				}
				
				this.numMateriel = value; }
		}


		private int numCaracteristique;

		public int NumCaracteristique
		{
			get { return numCaracteristique; }
			set {  if (value == null)
                {
                    throw new ArgumentNullException("Le numéro matériel est nul");
                }

                numCaracteristique = value; }
		}

		private string valeur;

		public string Valeur
		{
			get { return this.valeur; }
			set {this.valeur = value; }
		}


	}
}
