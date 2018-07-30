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
    /// Interaction logic for TipKursaWindow.xaml
    /// </summary>
    public partial class TipKursaWindow : Window
    {
        private CollectionViewSource cvs;

        public TipKursaWindow()
        {
            TipKursaDAO.Read();
            InitializeComponent();
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;

            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.TipoviKursa;

            dgTipoviKursa.ItemsSource = cvs.View;
            dgTipoviKursa.IsReadOnly = true;
            dgTipoviKursa.SelectionMode = DataGridSelectionMode.Single;
            dgTipoviKursa.AutoGenerateColumns = false;

            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Nivo";
            c.Binding = new Binding("Nivo");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgTipoviKursa.Columns.Add(c);
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            TipKursa t = new TipKursa();
            TipoviKursaEditWindow tew = new TipoviKursaEditWindow(t);
            tew.ShowDialog();
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            TipKursa t = dgTipoviKursa.SelectedItem as TipKursa;
            TipoviKursaEditWindow tew = new TipoviKursaEditWindow(t, MOD.IZMENA);
            tew.ShowDialog();
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                TipKursa t = dgTipoviKursa.SelectedItem as TipKursa;
                foreach (Kurs k in Aplikacija.Instanca.Kursevi)
                {
                    if (k.Tip.Id == t.Id)
                    {
                        MessageBox.Show("Ne mozete obrisati tip kursa zato sto je referenciran u kursu.", "Greska");
                        return;
                    }
                }
                Aplikacija.Instanca.TipoviKursa.Remove(t);
                TipKursaDAO.Delete(t);
            }

            if (Aplikacija.Instanca.TipoviKursa.Count == 0)
            {
                bObrisi.IsEnabled = false;
                bIzmeni.IsEnabled = false;
            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgTipoviKursa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bIzmeni.IsEnabled = true;
            bObrisi.IsEnabled = true;
        }
    }
}
