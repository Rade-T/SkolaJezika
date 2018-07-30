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
using System.ComponentModel;
using SkolaJezikaWPF.DAO;

namespace SkolaJezikaWPF
{

    public partial class KorisniciWindow : Window
    {
        private CollectionViewSource cvs;

        public KorisniciWindow()
        {
            KorisnikDAO.Read();
            InitializeComponent();
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;
            rbIme.IsChecked = true;
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Korisnici;
            dgKorisnici.ItemsSource = cvs.View;

            cvs.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Ascending));
            dgKorisnici.SelectedItem = null;

            //dgKorisnici.ItemsSource = Aplikacija.Instanca.Korisnici;
            //dgKorisnici.AutoGenerateColumns = true;
            dgKorisnici.IsReadOnly = true;
            dgKorisnici.SelectionMode = DataGridSelectionMode.Single;

            dgKorisnici.AutoGenerateColumns = false;
            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Ime";
            c.Binding = new Binding("Ime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKorisnici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Prezime";
            c.Binding = new Binding("Prezime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKorisnici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "JMBG";
            c.Binding = new Binding("JMBG");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKorisnici.Columns.Add(c);
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = new Korisnik();
            KorisniciEditWindow kew = new KorisniciEditWindow(k);
            kew.ShowDialog();
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = dgKorisnici.SelectedItem as Korisnik;
            KorisniciEditWindow kew = new KorisniciEditWindow(k, MOD.IZMENA);
            kew.ShowDialog();
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik k = dgKorisnici.SelectedItem as Korisnik;
                Aplikacija.Instanca.Korisnici.Remove(dgKorisnici.SelectedItem as Korisnik);
                KorisnikDAO.Delete(k);
            }

            if (Aplikacija.Instanca.Korisnici.Count == 0) 
            {
                bObrisi.IsEnabled = false;
                bIzmeni.IsEnabled = false;
            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bDodajTip_Click(object sender, RoutedEventArgs e)
        {
            TipKorisnika t = new TipKorisnika("Direktor", "...");
            Aplikacija.Instanca.TipoviKorisnika.Add(t);
            TipKorisnikaDAO.Create(t);
        }

        private void dgKorisnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bObrisi.IsEnabled = true;
            bIzmeni.IsEnabled = true;
        }

        private void MyFilter(object sender, FilterEventArgs e)
        {
            Korisnik k = e.Item as Korisnik;
            string kategorija = "";

            if (rbIme.IsChecked == true)
            {
                kategorija = k.Ime;
            }
            else if (rbPrezime.IsChecked == true)
            {
                kategorija = k.Prezime;
            }
            else if(rbJMBG.IsChecked == true)
            {
                kategorija = k.JMBG;
            }
            if (k != null)
            {
                e.Accepted = kategorija.ToLower().Contains(tbPretragaImena.Text.ToLower());
            }
        }

        private void tbPretragaImena_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }

        private void miOProgramu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Skola jezika v1.0\nUradio: Pera Peric SW12345", "O programu", MessageBoxButton.OK);
        }

        private void rbIme_Click(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }
    }
}
