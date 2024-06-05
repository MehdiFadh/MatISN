using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class DetailCommande : Table
    {

		private int numCommande;

		public int NumCommande
		{
			get { return this.numCommande; }
			set { this.numCommande = value; }
		}

		private int numMatriel;

		public int NumMateriel
		{
			get { return this.numMatriel; }
			set { this.numMatriel = value; }
		}

		private int quantite;

		public int Quantite
		{
			get { return this.quantite; }
			set { if(value < 1 || value > 100)
				{
					throw new ArgumentOutOfRangeException("La quantite doit être compris entre 1 et 100");
				}
				this.quantite = value; }
		}


	}
}
