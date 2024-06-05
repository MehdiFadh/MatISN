﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatISN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Materiel> MaterielsSuivie { get; set; }

        private List<Materiel> Materiels;


        public MainWindow()
        {
            InitializeComponent();
            AjouterText(txtPrenom, null);
            AjouterText(txtNom, null);
            AjouterText(txtNomUtilisateur, null);
            AjouterText(txtEmail, null);
            AjouterText(txtTelephone, null);

            EquipmentList.Items.Filter = ContientMotClef;
            

            MaterielsSuivie = new List<Materiel>
            {
                new Materiel { Nom = "Barre Hulligan", Categorie = "Outils", Prix = 128.00 },
                new Materiel { Nom = "Lance incendie", Categorie = "Outils", Prix = 250.00 },
                new Materiel { Nom = "Lance incendie", Categorie = "Outils", Prix = 120.00 },
                new Materiel { Nom = "Hache camp", Categorie = "Outils", Prix = 116.41 },
                new Materiel { Nom = "Tuyau", Categorie = "Outils", Prix = 220.00 },
                new Materiel { Nom = "Gants robuste", Categorie = "Vêtements", Prix = 50.00 },
                new Materiel { Nom = "Couteau pliant", Categorie = "Outils", Prix = 12.00 },
                

            };

            
            MaterialDataGrid2.ItemsSource = MaterielsSuivie;


            pageConnection dialogConnection = new pageConnection();
            dialogConnection.ShowDialog();

            ChargementEquipement();
            
            MiseJourListe();
            butFiltreCategorie.ItemsSource = Materiels.Select(e => e.Categorie).Distinct().ToList();


        }

        private void ChargementEquipement()
        {
            

            Materiels = new List<Materiel>
            {
                new Materiel { Nom = "Casque", NomFournisseur = "GGGG", Categorie = "Protection", Prix = 120.0, LienPhoto = "img\\Casque_de_pompier.jpg", Quantite = 1},
                new Materiel { Nom = "Hache", NomFournisseur = "GGGG", Categorie = "Outils", Prix = 50.0, LienPhoto = "img\\Hache.jpg" , Quantite = 1},
                new Materiel { Nom = "Extincteur", NomFournisseur = "GGGG", Categorie = "Équipement", Prix = 80.0, LienPhoto = "img\\Extincteur.jpg", Quantite = 1},
                new Materiel { Nom = "Lance à eau", NomFournisseur = "GGGG", Categorie = "Outils", Prix = 120.0, LienPhoto = "img\\lance_a_eau.png", Quantite = 1},
                new Materiel { Nom = "Botte", NomFournisseur = "GGGG", Categorie = "Protection", Prix = 50.0, LienPhoto = "img\\botte_pompier.jpg", Quantite = 1},
                new Materiel { Nom = "Veste", NomFournisseur = "GGGG", Categorie = "Protection", Prix = 80.0, LienPhoto = "img\\veste_pompier.jpg", Quantite = 1},
                new Materiel { Nom = "Corde", NomFournisseur = "GGGG", Categorie = "Outils", Prix = 50.0, LienPhoto = "img\\corde.jpg" , Quantite = 1},
                new Materiel { Nom = "Extincteur", NomFournisseur = "GGGG", Categorie = "Outils", Prix = 80.0, LienPhoto = "img\\tuyau.jpg", Quantite = 1},
                
            };

            foreach (var materiel in Materiels)
            {
                materiel.PropertyChanged += EquipementChanger;
            }
        }

        private void EquipementChanger(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Materiel.IsSelected) || e.PropertyName == nameof(Materiel.Quantite))
            {
                MiseJourListe();
                ChargePrixTotal();
            }
        }

        private void MiseJourListe()
        {
            EquipmentList.ItemsSource = null;
            EquipmentList.ItemsSource = Materiels;
            ChargeCompteur();
        }

        private void ChargeCompteur()
        {
            int selectedCount = Materiels.Count(e => e.IsSelected);
            SelectedCountText.Text = $"Matériel sélectionné: {selectedCount}";
            int selectedCountSuivie = MaterielsSuivie.Count(e => e.IsSelected);
            TxtArticlSelect.Text = $"{selectedCountSuivie} Matériel sélectionné";

        }

        private void FiltreCategorie_Loaded(object sender, RoutedEventArgs e)
        {
            var categories = Materiels.Select(e => e.Categorie).Distinct().ToList();
            categories.Insert(0, "Tous"); 
            butFiltreCategorie.ItemsSource = categories;
            butFiltreCategorie.SelectedIndex = 0; 
        }

        private void butFiltre_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategory = butFiltreCategorie.SelectedItem as string;
            if (selectedCategory == "Tous")
            {
                EquipmentList.ItemsSource = Materiels;
            }
            else if (!string.IsNullOrEmpty(selectedCategory))
            {
                EquipmentList.ItemsSource = Materiels.Where(e => e.Categorie == selectedCategory).ToList();
            }
        }

        private void textMotClef_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(EquipmentList.ItemsSource).Refresh();
        }


        private void EnleverText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "ex : Christophe" || textBox.Text == "ex : François" || textBox.Text == "ex : christophe.francois" || textBox.Text == "ex : christophe@exemple.com" || textBox.Text == "ex : 0612111180"))
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        private void AjouterText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == txtPrenom)
                    textBox.Text = "ex : Christophe";
                else if (textBox == txtNom)
                    textBox.Text = "ex : François";
                else if (textBox == txtNomUtilisateur)
                    textBox.Text = "ex : christophe.francois";
                else if (textBox == txtEmail)
                    textBox.Text = "ex : christophe@exemple.com";
                else if (textBox == txtTelephone)
                    textBox.Text = "ex : 0612111180";
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }

        }

        private void butProfil_Click(object sender, RoutedEventArgs e)
        {
            GridListeMateriel.Visibility = Visibility.Collapsed;
            GridSuivieDemande.Visibility = Visibility.Collapsed;
            GridProfil.Visibility = Visibility.Visible;
        }

        private void butMateriel_Click(object sender, RoutedEventArgs e)
        {
            GridProfil.Visibility= Visibility.Collapsed;
            GridSuivieDemande.Visibility = Visibility.Collapsed;
            GridListeMateriel.Visibility = Visibility.Visible;
        }

        private void butSuivieM_Click(object sender, RoutedEventArgs e)
        {
            GridProfil.Visibility = Visibility.Collapsed;
            GridListeMateriel.Visibility= Visibility.Collapsed;
            GridSuivieDemande.Visibility = Visibility.Visible;
        }


        public void ChargePrixTotal()
        {
            double PrixTotal = Materiels.Where(e => e.IsSelected).Sum(e => e.PrixTotal);
            txtPrixTotal.Text = $"Prix total : {PrixTotal:C}";
        }

        private void SelectionSuivie(object sender, PropertyChangedEventArgs e)
        {
            int selectedCountSuivie = MaterielsSuivie.Count(e => e.IsSelected);
            TxtArticlSelect.Text = $"{selectedCountSuivie} articles sélectionné";
        }

        private void DateLivraison_Click(object sender, RoutedEventArgs e)
        {
            MaterialDataGridDateLivraison.ItemsSource = MaterielsSuivie.Where(e => e.IsSelected);

            GridSuivieDemande.Visibility = Visibility.Collapsed;
            GridDateLivraison.Visibility = Visibility.Visible;
        }

        private void AnnulerLivraison_Click(object sender, RoutedEventArgs e)
        {
            GridSuivieDemande.Visibility = Visibility.Visible;
            GridDateLivraison.Visibility = Visibility.Collapsed;
        }

        private void ValiderDateLivraison_Click(object sender, RoutedEventArgs e)
        {
            GridSuivieDemande.Visibility = Visibility.Visible;
            GridDateLivraison.Visibility = Visibility.Collapsed;
        }

        private bool ContientMotClef(object obj)
        {
            Materiel unMateriel = obj as Materiel;
            if (String.IsNullOrEmpty(textMotClef.Text) || String.IsNullOrEmpty(textMotClefSuivie.Text))
                return true;
            else
                return (unMateriel.Nom.StartsWith(textMotClef.Text, StringComparison.OrdinalIgnoreCase)
                || unMateriel.Categorie.StartsWith(textMotClef.Text, StringComparison.OrdinalIgnoreCase)) || (unMateriel.Nom.StartsWith(textMotClefSuivie.Text, StringComparison.OrdinalIgnoreCase)
                || unMateriel.Categorie.StartsWith(textMotClefSuivie.Text, StringComparison.OrdinalIgnoreCase));
        }


        

    }
}
