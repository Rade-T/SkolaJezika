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
using SkolaJezikaWPF.EditWindows;
using SkolaJezikaWPF.DAO;

namespace SkolaJezikaWPF.Windows
{
    /// <summary>
    /// Interaction logic for UceniciWindow.xaml
    /// </summary>
    public partial class UceniciWindow : Window
    {
        private CollectionViewSource cvs;

        public UceniciWindow()
        {
            UcenikDAO.Read();
            InitializeComponent();
            InitializeComponent();
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;
            rbIme.IsChecked = true;

            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Ucenici;

            dgUcenici.ItemsSource = cvs.View;
            dgUcenici.IsReadOnly = true;
            dgUcenici.SelectionMode = DataGridSelectionMode.Single;
            dgUcenici.AutoGenerateColumns = false;

            string[] kolone = new string[] { "Ime", "Prezime", "JMBG" };
            for (int i = 0; i < kolone.Length; i++)
            {
                DataGridTextColumn c = new DataGridTextColumn();
                c.Header = kolone[i];
                c.Binding = new Binding(kolone[i]);
                c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                dgUcenici.Columns.Add(c);
            }
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = new Ucenik();
            UceniciEditWindow uew = new UceniciEditWindow(u);
            uew.ShowDialog();
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = dgUcenici.SelectedItem as Ucenik;
            UceniciEditWindow uew = new UceniciEditWindow(u, MOD.IZMENA);
            uew.ShowDialog();
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Ucenik u = dgUcenici.SelectedItem as Ucenik;
                foreach (Kurs k in Aplikacija.Instanca.Kursevi)
                {
                    foreach (Ucenik ucenikKursa in k.Ucenici)
                    {
                        if (ucenikKursa.Id == u.Id)
                        {
                            MessageBox.Show("Ne mozete obrisati ucenika zato sto je referenciran u kursu.", "Greska");
                            return;
                        }
                    }
                }
                foreach (Uplata uplata in Aplikacija.Instanca.Uplate)
                {
                    if (uplata.Ucenik.Id == u.Id)
                    {
                        MessageBox.Show("Ne mozete obrisati ucenika zato sto je referenciran u uplati.", "Greska");
                        return;
                    }
                }
                Aplikacija.Instanca.Ucenici.Remove(u);
                UcenikDAO.Delete(u);
            }

            if (Aplikacija.Instanca.Ucenici.Count == 0)
            {
                bObrisi.IsEnabled = false;
                bIzmeni.IsEnabled = false;
            }
        }

        private void bIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgUcenici_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            Ucenik u = e.Item as Ucenik;
            string pojam = "";
            if ((bool)rbIme.IsChecked)
            {
                pojam = u.Ime;
            }
            else if ((bool)rbPrezime.IsChecked)
            {
                pojam = u.Prezime;
            }
            else if ((bool)rbJMBG.IsChecked)
            {
                pojam = u.JMBG;
            }
            if (u != null)
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
