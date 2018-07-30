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
using SkolaJezikaWPF.Windows;
using SkolaJezikaWPF.DAO;

namespace SkolaJezikaWPF.EditWindows
{
    /// <summary>
    /// Interaction logic for KurseviEditWindow.xaml
    /// </summary>
    public partial class KurseviEditWindow : Window
    {
        protected Kurs original, copyObj;
        protected MOD mod;
        private CollectionViewSource cvs;

        public KurseviEditWindow()
        {
            InitializeComponent();
            lbJezik.ItemsSource = Aplikacija.Instanca.Jezici;
            lbPredavac.ItemsSource = Aplikacija.Instanca.Nastavnici;
            cbTipKursa.ItemsSource = Aplikacija.Instanca.TipoviKursa;
            cbTipKursa.SelectedIndex = 0;
        }

        public KurseviEditWindow(Kurs k, MOD m = MOD.DODAVANJE) : this()
        {
            this.original = k;
            this.mod = m;
            this.copyObj = original.Clone() as Kurs;
            this.DataContext = copyObj;

            cvs = new CollectionViewSource();
            cvs.Source = original.Ucenici;
            dgUcenici.ItemsSource = cvs.View;
            dgUcenici.IsReadOnly = true;
            dgUcenici.SelectionMode = DataGridSelectionMode.Single;

            dgUcenici.AutoGenerateColumns = false;
            DataGridTextColumn c = new DataGridTextColumn();
            c.Header = "Ime";
            c.Binding = new Binding("Ime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUcenici.Columns.Add(c);

            c = new DataGridTextColumn();
            c.Header = "Prezime";
            c.Binding = new Binding("Prezime");
            c.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUcenici.Columns.Add(c);
        }

        private void bIzmeniUcenike_Click(object sender, RoutedEventArgs e)
        {
            UceniciKursa uk = new UceniciKursa(original);
            uk.ShowDialog();
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.SetValues(copyObj);

            if (mod == MOD.DODAVANJE)
            {
                try
                {
                    Aplikacija.Instanca.Kursevi.Add(original);
                    KursDAO.Create(original);
                }
                catch { }
            }
            else
            {
                try { KursDAO.Update(original); }
                catch { }
            }
            KursDAO.Read();
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
