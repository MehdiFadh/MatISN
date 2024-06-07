using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class Materiel
    {
        private int quantite;
        private bool isSelected;
       
        public string Nom { get; set; }
        public string Categorie { get; set; }


        //PRIX
        private double prix;
        public double Prix
        {
            get { return this.prix; }
            set { this.prix = value; }
        }

        public Materiel(int numMateriel, int numFournisseur, string codeType, string descriptionMateriel, string lienPhoto, string marque, string description, double prix)
        {
            NumMateriel = numMateriel;
            NumFournisseur = numFournisseur;
            CodeType = codeType;
            DescriptionMateriel = descriptionMateriel;
            LienPhoto = lienPhoto;
            Marque = marque;
            Description = description;
            Prix = prix;
        }

        public Materiel()
        {
        }

        public string NomFournisseur { get; set; }


        private int numMateriel;

        public int NumMateriel
        {
            get { return this.numMateriel; }
            set { this.numMateriel = value; }
        }


        private int numFournisseur;

        public int NumFournisseur
        {
            get { return this.numFournisseur; }
            set { this.numFournisseur = value; }
        }


        private string codeType;

        public string CodeType
        {
            get { return this.codeType; }
            set { this.codeType = value; }
        }


        private string descriptionMateriel;

        public string DescriptionMateriel
        {
            get { return this.descriptionMateriel; }
            set { this.descriptionMateriel = value; }
        }


        private string lienPhoto;

        public string LienPhoto
        {
            get { return this.lienPhoto; }
            set { this.lienPhoto = value; }
        }

        private string marque;

        public string Marque
        {
            get { return this.marque; }
            set { this.marque = value; }
        }

        private string description;

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
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
                    OnPropertyChanged(nameof(PrixTotal));
                }
            }
        }
        
        
       
        public int Quantite
        {
            get { return quantite; }
            set
            {
                if (quantite != value)
                {
                    quantite = value;
                    OnPropertyChanged(nameof(Quantite));
                    OnPropertyChanged(nameof(PrixTotal));
                }

            }
        }






        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        

        public double PrixTotal
        {
            get { 

                    if(IsSelected)
                    {
                        return Quantite * Prix;
                    }
                    else
                    {
                        return 0;
                    }
                
                }
            
        }
        

    }



}
