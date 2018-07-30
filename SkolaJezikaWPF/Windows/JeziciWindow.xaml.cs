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
using SkolaJezikaWPF;
using SkolaJezikaWPF.DAO;

namespace SkolaJezikaWPF.Windows
{
    /// <summary>
    /// Interaction logic for JeziciWindow.xaml
    /// </summary>
    public partial class JeziciWindow : Window
    {
        private CollectionViewSource cvs;

        public JeziciWindow()
        {
            JezikDAO.Read();
            InitializeComponent();
            bIzmeni.IsEnabled = false;
            bObrisi.IsEnabled = false;

            cvs = new CollectionViewSource();
            cvs.Source = Aplikacija.Instanca.Jezici;

            dgJezici.ItemsSource = cvs.View;
            dgJezici.IsReadOnly = true;
            dgJezici.SelectionMode = DataGridSelectionMode.Single;
            dgJezici.AutoGenerateColumns = false;

            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Naziv";
            c.Binding = new Binding("Naziv");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgJezici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Oznaka";
            c.Binding = new Binding("Oznaka");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgJezici.Columns.Add(c);
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Jezik j = new Jezik();
            JeziciEditWindow jew = new JeziciEditWindow(j);
            jew.ShowDialog();
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Jezik j = dgJezici.SelectedItem as Jezik;
            JeziciEditWindow jew = new JeziciEditWindow(j, MOD.IZMENA);
            jew.ShowDialog();
        }

        private void bObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda brisanja", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Jezik j = dgJezici.SelectedItem as Jezik;
                foreach (Kurs k in Aplikacija.Instanca.Kursevi)
                {
                    if (k.JezikKursa.Id == j.Id)
                    {
                        MessageBox.Show("Ne mozete obrisati jezik zato sto je referenciran u kursu.", "Greska");
                        return;
                    }
                }
                Aplikacija.Instanca.Jezici.Remove(j);
                JezikDAO.Delete(j);
            }

            if (Aplikacija.Instanca.Jezici.Count == 0)
            {
                bObrisi.IsEnabled = false;
                bIzmeni.IsEnabled = false;
            }
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgJezici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bObrisi.IsEnabled = true;
            bIzmeni.IsEnabled = true;
        }
    }
}
