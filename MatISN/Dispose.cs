using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class Dispose
    {
		private Materiel unMateriel;

		private string nomHabilitation;

		public string NomHabilitation
		{
			get { return this.nomHabilitation; }
			set {
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("La valeur ne peut pas être null");
				}

				this.nomHabilitation = value; }
		}

        public Materiel UnMateriel
        {
            get
            {
                return unMateriel;
            }

            set
            {
                unMateriel = value;
            }
        }
    }
}
