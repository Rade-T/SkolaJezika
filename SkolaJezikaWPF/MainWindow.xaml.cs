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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkolaJezikaWPF.Windows;
using SkolaJezikaConsole;

namespace SkolaJezikaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            foreach (Korisnik k in Aplikacija.Instanca.Korisnici)
            {
                if (k.LogIn(tbKime.Text, pwLozinka.Password))
                {
                    GlavniWindow gw = new GlavniWindow(k);
                    gw.Show();
                    this.Close();
                }
            }

        }

        
    }
}
