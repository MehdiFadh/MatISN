using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Fournisseur unFournisseur;
        private Caserne uneCaserne;
        private Mode_transport unModeTransport;
        public bool isSelected;

        public Commande()
        {
            this.numCommande = ajoutCommande;
            ajoutCommande++;
        }

        public Commande(DateTime dateCommande, DateTime dateLivraison, Caserne uneCaserne, Mode_transport unModeTransport, Fournisseur unFournisseur)
        {
            DateCommande = dateCommande;
            DateLivraison = dateLivraison;
            UneCaserne = uneCaserne;
            UnModeTransport = unModeTransport;
            UnFournisseur = unFournisseur;
            this.numCommande = ajoutCommande;
            ajoutCommande++;
        }

        public Commande( int numTransport, int numCaserne, DateTime dateCommande, DateTime dateLivraison)
        {
            DateCommande = dateCommande;
            DateLivraison = dateLivraison;
            NumCaserne = numCaserne;
            numTransport = numTransport;

            
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

        private int numCaserne;

        public int NumCaserne
        {
            get { return numCaserne; }
            set { numCaserne = value; }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Fournisseur UnFournisseur { get => unFournisseur; set => unFournisseur = value; }
    }
}
