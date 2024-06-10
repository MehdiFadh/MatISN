using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
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
        public Commande commandeSelect;
        public ObservableCollection<Material> materialList;
        public ObservableCollection<Commande> commandeList;

        public MainWindow()
        {
            InitializeComponent();
            AjouterText(txtPrenom, null);
            AjouterText(txtNom, null);
            AjouterText(txtNomUtilisateur, null);
            AjouterText(txtEmail, null);
            AjouterText(txtTelephone, null);

            EquipmentList.Items.Filter = ContientMotClef;
            



            
            //MaterialDataGrid2.ItemsSource = ;


            pageConnection dialogConnection = new pageConnection();
            dialogConnection.ShowDialog();

            ChargementEquipement();
            
            MiseJourListe();
            //butFiltreCategorie.ItemsSource = EquipmentList.Items.Select(e => e.Categorie).Distinct().ToList();


        }

        private void ChargementEquipement()
        {
            



            foreach (var materiel in EquipmentList.Items)
            {
                Materiel unMateriel = materiel as Materiel;
                unMateriel.PropertyChanged += EquipementChanger;
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
            ChargeCompteur();
        }

        private void ChargeCompteur()
        {
            /*materialList = EquipmentList.Items;
            int selectedCount = materialList.Count(e => e.IsSelected);
            SelectedCountText.Text = $"Matériel sélectionné: {selectedCount}";
            int selectedCountSuivie = materialList.Count(e => e.IsSelected);
            TxtArticlSelect.Text = $"{selectedCountSuivie} Matériel sélectionné";*/

        }

        private void FiltreCategorie_Loaded(object sender, RoutedEventArgs e)
        {
            /*var categories = Materiels.Select(e => e.Categorie).Distinct().ToList();
            categories.Insert(0, "Tous"); 
            butFiltreCategorie.ItemsSource = categories;
            butFiltreCategorie.SelectedIndex = 0; */
        }

        private void butFiltre_Click(object sender, RoutedEventArgs e)
        {
           /* string selectedCategory = butFiltreCategorie.SelectedItem as string;
            if (selectedCategory == "Tous")
            {
                EquipmentList.ItemsSource = EquipmentList.Items;
            }
            else if (!string.IsNullOrEmpty(selectedCategory))
            {
                EquipmentList.ItemsSource = EquipmentList.Items.(e => e.Categorie == selectedCategory).ToList();
            }*/
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
            /*double PrixTotal = Materiels.Where(e => e.IsSelected).Sum(e => e.PrixTotal);
            txtPrixTotal.Text = $"Prix total : {PrixTotal:C}";*/
        }

        private void SelectionSuivie(object sender, PropertyChangedEventArgs e)
        {
           /* int selectedCountSuivie = MaterielsSuivie.Count(e => e.IsSelected);
            TxtArticlSelect.Text = $"{selectedCountSuivie} articles sélectionné";*/
        }

        private void DateLivraison_Click(object sender, RoutedEventArgs e)
        {
            //commandeSelect = MaterialDataGrid2.Items;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Commande test = new Commande();
            //data.Create(test);
            
        }
    }
}
