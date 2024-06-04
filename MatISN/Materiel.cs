using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatISN
{
    public class Materiel : Table
    {
        private int quantite;
        private bool isSelected;
       
        public string Nom { get; set; }
        public string Categorie { get; set; }
        public double Prix { get; set; }
        public string CheminImage { get; set; }

        public string NomFournisseur { get; set; }


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

      

        public override int Create()
        {
            Sql = "";
            return base.Create();
        }

        public override int Delete()
        {
            Sql = "";
            return base.Delete();
        }

        public override int Update()
        {
            Sql = "";
            return base.Update();
        }


    }



}
