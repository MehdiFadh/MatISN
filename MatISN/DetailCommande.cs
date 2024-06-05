using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    internal class DetailCommande
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
			set { this.quantite = value; }
		}


	}
}
