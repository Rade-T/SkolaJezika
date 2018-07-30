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
    /// Interaction logic for NastavniciEditWindow.xaml
    /// </summary>
    public partial class NastavniciEditWindow : Window
    {
        protected Nastavnik original, copyObj;
        protected MOD mod;

        public NastavniciEditWindow()
        {
            InitializeComponent();
        }

        public NastavniciEditWindow(Nastavnik n, MOD m = MOD.DODAVANJE)
            : this()
        {
            this.original = n;
            this.mod = m;
            this.copyObj = original.Clone() as Nastavnik;
            this.DataContext = copyObj;

            if (mod == MOD.IZMENA)
            {
                tbJmbg.IsEnabled = false;
            }
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.setValues(copyObj);

            if (mod == MOD.DODAVANJE)
            {
                try
                {
                    NastavnikDAO.Create(original);
                    Aplikacija.Instanca.Nastavnici.Add(original);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Greska", MessageBoxButton.OK);
                }
            }
            else
            {
                try
                {
                    NastavnikDAO.Update(original);
                }
                catch
                {

                }
            }
            NastavnikDAO.Read();
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
