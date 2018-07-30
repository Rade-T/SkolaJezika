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
    /// Interaction logic for UplateWindow.xaml
    /// </summary>
    public partial class UplateWindow : Window
    {
        private CollectionViewSource cvs;

        public UplateWindow()
        {
            UplateDAO.Read();
            InitializeComponent();
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;
            rbImeUcenikKursa.IsEnabled = false;
            rbPrezimeUcenikKursa.IsEnabled = false;
            rbJMBGUcenikKursa.IsEnabled = false;
            rbIme.IsEnabled = false;
            rbPrezime.IsEnabled = false;
            rbJMBG.IsEnabled = false;
            rbIme.IsChecked = true;
            rbImeUcenikKursa.IsChecked = true;
            rbJezik.IsChecked = true;
            rbKurs.IsChecked = true;

            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Uplate;
            dgUplate.ItemsSource = cvs.View;

            dgUplate.IsReadOnly = true;
            dgUplate.SelectionMode = DataGridSelectionMode.Single;
            dgUplate.AutoGenerateColumns = false;

            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Ucenik";
            c.Binding = new Binding("Ucenik.ImePrezime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUplate.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Kurs";
            c.Binding = new Binding("Kurs.JezikKursa");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUplate.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Cena";
            c.Binding = new Binding("Cena");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUplate.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Datum";
            c.Binding = new Binding("Datum");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUplate.Columns.Add(c);
        }

        private void dgUplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bObrisi.IsEnabled = true;
            bIzmeni.IsEnabled = true;
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Uplata u = new Uplata();
            UplateEditWindow uew = new UplateEditWindow(u);
            uew.ShowDialog();
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Uplata u = dgUplate.SelectedItem as Uplata;
            UplateEditWindow uew = new UplateEditWindow(u, MOD.IZMENA);
            uew.ShowDialog();
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Uplata u = dgUplate.SelectedItem as Uplata;
                Aplikacija.Instanca.Uplate.Remove(u);
                UplateDAO.Delete(u);
            }

            if (Aplikacija.Instanca.Uplate.Count == 0)
            {
                bObrisi.IsEnabled = false;
                bIzmeni.IsEnabled = false;
            }
        }

        private void bIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }

        private void MyFilter(object sender, FilterEventArgs e)
        {
            Uplata u = e.Item as Uplata;
            if (rbKurs.IsChecked == true)
            {
                rbIme.IsEnabled = false;
                rbPrezime.IsEnabled = false;
                rbJMBG.IsEnabled = false;
                rbJezik.IsEnabled = true;
                rbUcenikKursa.IsEnabled = true;

                if (rbJezik.IsChecked == true)
                {
                    rbImeUcenikKursa.IsEnabled = false;
                    rbPrezimeUcenikKursa.IsEnabled = false;
                    rbJMBGUcenikKursa.IsEnabled = false;

                    if (u != null)
                    {
                        e.Accepted = u.Kurs.JezikKursa.Naziv.ToLower().Contains(tbPretraga.Text.ToLower());
                    }
                }

                else if (rbUcenikKursa.IsChecked == true)
                {
                    rbJezik.IsEnabled = true;
                    rbUcenikKursa.IsEnabled = true;
                    rbImeUcenikKursa.IsEnabled = true;
                    rbPrezimeUcenikKursa.IsEnabled = true;
                    rbJMBGUcenikKursa.IsEnabled = true;
                    

                    if (rbImeUcenikKursa.IsChecked == true)
                    {
                        if (u != null)
                        {
                            foreach (Ucenik uc in u.Kurs.Ucenici)
                            {
                                if (uc.Ime.ToLower().Contains(tbPretraga.Text.ToLower()))
                                {
                                    e.Accepted = true;
                                    return;
                                }
                            }
                            e.Accepted = false;
                        }
                    }
                    else if (rbPrezimeUcenikKursa.IsChecked == true)
                    {
                        if (u != null)
                        {
                            foreach (Ucenik uc in u.Kurs.Ucenici)
                            {
                                if (uc.Prezime.ToLower().Contains(tbPretraga.Text.ToLower()))
                                {
                                    e.Accepted = true;
                                    return;
                                }
                            }
                            e.Accepted = false;
                        }
                    }
                    else if (rbJMBGUcenikKursa.IsChecked == true)
                    {
                        if (u != null)
                        {
                            foreach (Ucenik uc in u.Kurs.Ucenici)
                            {
                                if (uc.JMBG.ToLower().Contains(tbPretraga.Text.ToLower()))
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
            else
            {
                rbJezik.IsEnabled = false;
                rbUcenikKursa.IsEnabled = false;
                rbImeUcenikKursa.IsEnabled = false;
                rbPrezimeUcenikKursa.IsEnabled = false;
                rbJMBGUcenikKursa.IsEnabled = false;
                rbIme.IsEnabled = true;
                rbPrezime.IsEnabled = true;
                rbJMBG.IsEnabled = true;

                if ((bool)rbIme.IsChecked)
                {
                    if (u != null)
                    {
                        e.Accepted = u.Ucenik.Ime.ToLower().Contains(tbPretraga.Text.ToLower());
                    }
                }
                else if ((bool)rbPrezime.IsChecked)
                {
                    if (u != null)
                    {
                        e.Accepted = u.Ucenik.Prezime.ToLower().Contains(tbPretraga.Text.ToLower());
                    }
                }
                else if ((bool)rbJMBG.IsChecked)
                {
                    if (u != null)
                    {
                        e.Accepted = u.Ucenik.JMBG.ToLower().Contains(tbPretraga.Text.ToLower());
                    }
                }
                
            }
        }

        private void rbKurs_Click(object sender, RoutedEventArgs e)
        {
            cvs.Filter += new FilterEventHandler(MyFilter);
        }
    }
}
