using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class Commande
    {
        private static int ajoutCommande;
        private int numCommande;
        private DateTime dateCommande;
        private DateTime dateLivraison;
        private Caserne uneCaserne;
        private Mode_transport unModeTransport;

        public Commande()
        {
            this.numCommande = ajoutCommande;
            ajoutCommande++;
        }

        public Commande(DateTime dateCommande, DateTime dateLivraison, Caserne uneCaserne, Mode_transport unModeTransport)
        {
            DateCommande = dateCommande;
            DateLivraison = dateLivraison;
            UneCaserne = uneCaserne;
            UnModeTransport = unModeTransport;
            this.numCommande = ajoutCommande;
            ajoutCommande++;
        }

        public DateTime DateCommande
        {
            get
            {
                return dateCommande;
            }

            set
            {
                dateCommande = value;
            }
        }

        public DateTime DateLivraison
        {
            get
            {
                return dateLivraison;
            }

            set
            {
                dateLivraison = value;
            }
        }

        public Caserne UneCaserne
        {
            get
            {
                return uneCaserne;
            }

            set
            {
                uneCaserne = value;
            }
        }

        public Mode_transport UnModeTransport
        {
            get
            {
                return unModeTransport;
            }

            set
            {
                unModeTransport = value;
            }
        }

        public int NumCommande
        {
            get
            {
                return numCommande;
            }

            set
            {
                numCommande = value;
            }
        }
    }
}
