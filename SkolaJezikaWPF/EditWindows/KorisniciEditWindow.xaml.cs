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

namespace SkolaJezikaWPF
{
    /// <summary>
    /// Interaction logic for KorisniciEditWindow.xaml
    /// </summary>
    public enum MOD { DODAVANJE, IZMENA };

    public partial class KorisniciEditWindow : Window
    {
        protected Korisnik original, copyObj;
        protected MOD mod;

        public KorisniciEditWindow()
        {
            InitializeComponent();
        }

        public KorisniciEditWindow(Korisnik k, MOD m = MOD.DODAVANJE) : this()
        {
            this.original = k;
            this.mod = m;
            this.copyObj = original.Clone() as Korisnik;
            this.DataContext = copyObj;
            cbTip.ItemsSource = Aplikacija.Instanca.TipoviKorisnika;

            if (mod == MOD.IZMENA)
            {
                tbJmbg.IsEnabled = false;

            }
            else
            {
                //cbTip.SelectedItem =
            }
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.SetValues(copyObj);

            if (mod == MOD.DODAVANJE)
            {
                try
                {
                    Aplikacija.Instanca.Korisnici.Add(original);
                    KorisnikDAO.Create(original);
                }
                catch { }
            }
            else
            {
                try { KorisnikDAO.Update(original); }
                catch { }
            }
            KorisnikDAO.Read();
            this.DialogResult = true;
            this.Close();
        }
    }
}
