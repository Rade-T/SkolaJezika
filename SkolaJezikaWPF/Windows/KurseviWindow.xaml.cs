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
    /// Interaction logic for KurseviWindow.xaml
    /// </summary>
    public partial class KurseviWindow : Window
    {
        private CollectionViewSource cvs;

        public KurseviWindow()
        {
            KursDAO.Read();
            InitializeComponent();
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;
            rbUcenik.IsChecked = true;
            rbIme.IsChecked = true;
            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Kursevi;
            dgKursevi.ItemsSource = cvs.View;

            dgKursevi.IsReadOnly = true;
            dgKursevi.SelectionMode = DataGridSelectionMode.Single;

            dgKursevi.AutoGenerateColumns = false;
            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Jezik";
            c.Binding = new Binding("JezikKursa.Naziv");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Tip";
            c.Binding = new Binding("Tip.Nivo");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Cena";
            c.Binding = new Binding("Cena");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Predavac";
            c.Binding = new Binding("Predavac.ImePrezime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(c);
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = new Kurs();
            KurseviEditWindow kew = new KurseviEditWindow(k);
            kew.ShowDialog();
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgKursevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bIzmeni.IsEnabled = true;
            bObrisi.IsEnabled = true;
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = dgKursevi.SelectedItem as Kurs;
            KurseviEditWindow kew = new KurseviEditWindow(k, MOD.IZMENA);
            kew.ShowDialog();
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Kurs k = dgKursevi.SelectedItem as Kurs;
                foreach (Uplata u in Aplikacija.Instanca.Uplate)
                {
                    if (u.Kurs.Id == k.Id)
                    {
                        MessageBox.Show("Ne mozete obrisati kurs zato sto je referenciran u uplati.", "Greska");
                        return;
                    }
                }
                Aplikacija.Instanca.Kursevi.Remove(k);
                KursDAO.Delete(k);
            }

            if (Aplikacija.Instanca.Kursevi.Count == 0)
            {
                bObrisi.IsEnabled = false;
                bIzmeni.IsEnabled = false;
            }
        }

        private void MyFilter(object sender, FilterEventArgs e)
        {
            Kurs k = e.Item as Kurs;
            if (rbJezik.IsChecked == true)
            {
                rbIme.IsEnabled = false;
                rbPrezime.IsEnabled = false;
                rbJMBG.IsEnabled = false;

                if (k != null)
                {
                    e.Accepted = k.JezikKursa.Naziv.ToLower().Contains(tbPretraga.Text.ToLower());
                }
            }
            
            else if (rbUcenik.IsChecked == true)
            {
                rbIme.IsEnabled = true;
                rbPrezime.IsEnabled = true;
                rbJMBG.IsEnabled = true;

                if (rbIme.IsChecked == true)
                {
                    if (k != null)
                    {
                        foreach (Ucenik u in k.Ucenici)
                        {
                            if (u.Ime.ToLower().Contains(tbPretraga.Text.ToLower()))
                            {
                                e.Accepted = true;
                                return;
                            }
                        }
                        e.Accepted = false;
                    }
                }
                else if (rbPrezime.IsChecked == true)
                {
                    if (k != null)
                    {
                        foreach (Ucenik u in k.Ucenici)
                        {
                            if (u.Prezime.ToLower().Contains(tbPretraga.Text.ToLower()))
                            {
                                e.Accepted = true;
                                return;
                            }
                        }
                        e.Accepted = false;
                    }
                }
                else if (rbJMBG.IsChecked == true)
                {
                    if (k != null)
                    {
                        foreach (Ucenik u in k.Ucenici)
                        {
                            if (u.JMBG.ToLower().Contains(tbPretraga.Text.ToLower()))
                            {
                                e.Accepted = true;
                                return;
                            }
                        }
                        e.Accepted = false;
                    }
                }
            }
        }

        private void tbPretraga_TextChanged(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }
    }
}
