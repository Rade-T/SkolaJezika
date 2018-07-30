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

namespace SkolaJezikaWPF.Windows
{
    /// <summary>
    /// Interaction logic for UceniciKursa.xaml
    /// </summary>
    public partial class UceniciKursa : Window
    {
        private Kurs original, copyObj;
        private CollectionViewSource cvsSviUcenici, cvsUceniciKursa;

        public UceniciKursa()
        {
            InitializeComponent();
        }

        public UceniciKursa(Kurs k) : this()
        {
            this.original = k;
            this.copyObj = original.Clone() as Kurs;
            this.DataContext = copyObj;

            cvsSviUcenici = new CollectionViewSource();
            cvsSviUcenici.Source = Aplikacija.Instanca.Ucenici;
            dgSviUcenici.ItemsSource = cvsSviUcenici.View;
            dgSviUcenici.IsReadOnly = true;
            dgSviUcenici.SelectionMode = DataGridSelectionMode.Single;

            dgSviUcenici.AutoGenerateColumns = false;
            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Ime";
            c.Binding = new Binding("Ime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSviUcenici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Prezime";
            c.Binding = new Binding("Prezime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgSviUcenici.Columns.Add(c);

            cvsUceniciKursa = new CollectionViewSource();
            cvsUceniciKursa.Source = original.Ucenici;
            dgUceniciKursa.ItemsSource = cvsUceniciKursa.View;
            dgUceniciKursa.IsReadOnly = true;
            dgUceniciKursa.SelectionMode = DataGridSelectionMode.Single;

            dgUceniciKursa.AutoGenerateColumns = false;
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Ime";
            c1.Binding = new Binding("Ime");
            c1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUceniciKursa.Columns.Add(c1);

            c1 = new DataGridTextColumn();
            c1.Header = "Prezime";
            c1.Binding = new Binding("Prezime");
            c1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUceniciKursa.Columns.Add(c1);
        }

        private void bDodaj_Click(object sender, RoutedEventArgs e)
        {
            Ucenik zaDodavanje = dgSviUcenici.SelectedItem as Ucenik;

            foreach (Ucenik u in copyObj.Ucenici)
            {
                if (u.JMBG == zaDodavanje.JMBG)
                {
                    return;
                }
            }

            copyObj.Ucenici.Add(zaDodavanje);
        }

        private void bIzbaci_Click(object sender, RoutedEventArgs e)
        {
            Ucenik zaIzbacivanje = dgUceniciKursa.SelectedItem as Ucenik;
            this.copyObj.Ucenici.Remove(zaIzbacivanje);

            if (this.copyObj.Ucenici.Count == 0)
            {
                bIzbaci.IsEnabled = false;
            }
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.SetValues(copyObj);
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
