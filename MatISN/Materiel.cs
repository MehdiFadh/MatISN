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
       
        
        //PRIX
        private double prix;
        public double Prix
        {
            get { return this.prix; }
            set { this.prix = value; }
        }

        public Materiel(int numMateriel, Fournisseur unFournisseur, type_materiel untypeMateriel, string descriptionMateriel, string lienPhoto, string marque, string description, double prix)
        {
            NumMateriel = numMateriel;
            UnFournisseur = unFournisseur;
            UntypeMateriel = untypeMateriel;
            DescriptionMateriel = descriptionMateriel;
            LienPhoto = lienPhoto;
            Marque = marque;
            Description = description;
            Prix = prix;
        }

        public Materiel(int numMateriel, string nomFournisseur, string codeType, string descriptionMateriel, string lienPhoto, string marque, string description, double prix)
        {
            NumMateriel = numMateriel;
            NomFournisseur = nomFournisseur;
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

        private int numFournisseur;

        public int NumFournisseur
        {
            get { return numFournisseur; }
            set { numFournisseur = value; }
        }

        private string nomFournisseur;

        public string NomFournisseur
        {
            get { return nomFournisseur; }
            set { nomFournisseur = value; }
        }


        private int numMateriel;

        public int NumMateriel
        {
            get { return this.numMateriel; }
            set { this.numMateriel = value; }
        }


        private Fournisseur unFournisseur;



        private type_materiel untypeMateriel;



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

        private string codeType;

        public string CodeType
        {
            get { return codeType; }
            set { codeType = value; }
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

        public Fournisseur UnFournisseur
        {
            get
            {
                return unFournisseur;
            }

            set
            {
                unFournisseur = value;
            }
        }

        public type_materiel UntypeMateriel
        {
            get
            {
                return untypeMateriel;
            }

            set
            {
                untypeMateriel = value;
            }
        }
    }



}
