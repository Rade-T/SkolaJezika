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
using SkolaJezikaConsole;
using SkolaJezikaWPF.DAO;

namespace SkolaJezikaWPF.Windows
{
    /// <summary>
    /// Interaction logic for GlavniWindow.xaml
    /// </summary>
    public partial class GlavniWindow : Window
    {
        public GlavniWindow()
        {
            InitializeComponent();
            SkolaDAO.Read();
        }

        public GlavniWindow(Korisnik k) : this()
        {
            
            if (k.Tip.Naziv == "Administrator")
            {
                bKursevi.Visibility = Visibility.Collapsed;
                bUplate.Visibility = Visibility.Collapsed;
                bJezici.Visibility = Visibility.Collapsed;
                bTipoviKurseva.Visibility = Visibility.Collapsed;
            }
            if (k.Tip.Naziv == "Radnik")
            {
                bSkola.Visibility = Visibility.Collapsed;
                bNastavnici.Visibility = Visibility.Collapsed;
                bKorisnici.Visibility = Visibility.Collapsed;
            }
        }

        private void bNastavnici_Click(object sender, RoutedEventArgs e)
        {
            NastavniciWindow nw = new NastavniciWindow();
            nw.ShowDialog();
        }

        private void bUcenici_Click(object sender, RoutedEventArgs e)
        {
            UceniciWindow uw = new UceniciWindow();
            uw.ShowDialog();
        }

        private void bJezici_Click(object sender, RoutedEventArgs e)
        {
            JeziciWindow jw = new JeziciWindow();
            jw.ShowDialog();
        }

        private void bTipoviKursa_Click(object sender, RoutedEventArgs e)
        {
            TipKursaWindow tw = new TipKursaWindow();
            tw.ShowDialog();
        }

        private void bKorisnici_Click(object sender, RoutedEventArgs e)
        {
            KorisniciWindow kw = new KorisniciWindow();
            kw.ShowDialog();
        }

        private void bKursevi_Click(object sender, RoutedEventArgs e)
        {
            KurseviWindow kw = new KurseviWindow();
            kw.ShowDialog();
        }

        private void bUplate_Click(object sender, RoutedEventArgs e)
        {
            UplateWindow uw = new UplateWindow();
            uw.ShowDialog();
        }

        private void bIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bSkola_Click(object sender, RoutedEventArgs e)
        {
            SkolaWindow sw = new SkolaWindow();
            sw.ShowDialog();
        }
    }
}
