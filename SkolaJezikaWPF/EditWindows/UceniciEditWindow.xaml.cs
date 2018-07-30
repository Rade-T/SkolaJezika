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

namespace SkolaJezikaWPF.EditWindows
{
    /// <summary>
    /// Interaction logic for UceniciEditWindow.xaml
    /// </summary>
    public partial class UceniciEditWindow : Window
    {
        protected Ucenik original, copyObj;
        protected MOD mod;

        public UceniciEditWindow()
        {
            InitializeComponent();
        }

        public UceniciEditWindow(Ucenik u, MOD m = MOD.DODAVANJE)
        {
            InitializeComponent();
            this.original = u;
            this.mod = m;
            this.copyObj = original.Clone() as Ucenik;
            this.DataContext = copyObj;

            if (mod == MOD.IZMENA)
            {
                tbJmbg.IsEnabled = false;
            }
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.SetValues(copyObj);

            if (mod == MOD.DODAVANJE)
            {
                try
                {
                    Aplikacija.Instanca.Ucenici.Add(original);
                    UcenikDAO.Create(original);
                }
                catch { }
            }
            else
            {
                try { UcenikDAO.Update(original); }
                catch { }
            }
            UcenikDAO.Read();
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
