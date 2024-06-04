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

        private bool isSelected;

        private int quantite;
        //dfsdfgs
        public string Nom { get; set; }
        public string Categorie { get; set; }
        public double Prix { get; set; }
        public string CheminImage { get; set; }
        public bool IsSelected
        {
            get => isSelected;
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

                    if(isSelected)
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
