using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MatISN
{
    /// <summary>
    /// Logique d'interaction pour pageConnection.xaml
    /// </summary>
    public partial class pageConnection : Window
    {
        public string user = "";
        public string password = "";

        public pageConnection()
        {
            InitializeComponent();
            AjouterText(txtLogin, null);
            AjouterText(txtMDP, null);
            WindowStyle = WindowStyle.None;
            
        }


        private void EnleverText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && (textBox.Text == "" || textBox.Text == "Mots de passe"))
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
                if (textBox == txtLogin)
                    textBox.Text = "";
                else 
                    textBox.Text = "Mots de passe";
               
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }


        }

        private void butConnection_Click(object sender, RoutedEventArgs e)
        {
            user = txtLogin.Text;
           
            DialogResult = true;
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}