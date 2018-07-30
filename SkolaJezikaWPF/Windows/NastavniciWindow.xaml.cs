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
    /// <summary>
    /// Interaction logic for NastavniciWindow.xaml
    /// </summary>
    public partial class NastavniciWindow : Window
    {
        private CollectionViewSource cvs;

        public NastavniciWindow()
        {
            NastavnikDAO.Read();
            InitializeComponent();
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;
            rbIme.IsChecked = true;

            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Nastavnici;

            dgNastavnici.ItemsSource = cvs.View;
            dgNastavnici.IsReadOnly = true;
            dgNastavnici.SelectionMode = DataGridSelectionMode.Single;
            dgNastavnici.AutoGenerateColumns = false;

            string[] kolone = new string[] { "Ime", "Prezime", "JMBG" };
            for (int i = 0; i < kolone.Length; i++)
            {
                DataGridTextColumn c = new DataGridTextColumn();
                c.Header = kolone[i];
                c.Binding = new Binding(kolone[i]);
                c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                dgNastavnici.Columns.Add(c);
            }
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Nastavnik n = new Nastavnik();
            NastavniciEditWindow nw = new NastavniciEditWindow(n);
            nw.ShowDialog();
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Nastavnik n = dgNastavnici.SelectedItem as Nastavnik;
            NastavniciEditWindow nw = new NastavniciEditWindow(n, MOD.IZMENA);
            nw.ShowDialog();
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Nastavnik n = dgNastavnici.SelectedItem as Nastavnik;
                foreach (Kurs k in Aplikacija.Instanca.Kursevi)
                {
                    if (k.Predavac.Id == n.Id)
                    {
                        MessageBox.Show("Ne mozete obrisati nastavnika zato sto je referenciran u kursu.", "Greska");
                        return;
                    }
                }
                Aplikacija.Instanca.Nastavnici.Remove(n);
                NastavnikDAO.Delete(n);
            }

            if (Aplikacija.Instanca.Nastavnici.Count == 0)
            {
                bObrisi.IsEnabled = false;
                bIzmeni.IsEnabled = false;
            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgNastavnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bObrisi.IsEnabled = true;
            bIzmeni.IsEnabled = true;
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }

        private void MyFilter(object sender, FilterEventArgs e)
        {
            Nastavnik n = e.Item as Nastavnik;
            string pojam = "";
            if ((bool)rbIme.IsChecked)
            {
                pojam = n.Ime;
            }
            else if((bool)rbPrezime.IsChecked)
            {
                pojam = n.Prezime;
            }
            else if((bool)rbJMBG.IsChecked)
            {
                pojam = n.JMBG;
            }
            if (n != null)
            {
                e.Accepted = pojam.ToLower().Contains(tbPretraga.Text.ToLower());
            }
        }

        private void rbIme_Click(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }
    }
}
