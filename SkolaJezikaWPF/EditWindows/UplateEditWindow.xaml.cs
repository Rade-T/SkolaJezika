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
    /// Interaction logic for UplateEditWindow.xaml
    /// </summary>
    public partial class UplateEditWindow : Window
    {
        protected Uplata original, copyObj;
        protected MOD mod;

        public UplateEditWindow()
        {
            InitializeComponent();
        }

        public UplateEditWindow(Uplata u, MOD m = MOD.DODAVANJE) : this()
        {
            lbUcenik.ItemsSource = Aplikacija.Instanca.Ucenici;
            lbKurs.ItemsSource = Aplikacija.Instanca.Kursevi;
            this.original = u;
            this.mod = m;
            this.copyObj = original.Clone() as Uplata;
            this.DataContext = copyObj;

            if (m == MOD.IZMENA)
            {
                dpDatum.IsEnabled = false;
            }
            else
            {
                dpDatum.SelectedDate = DateTime.Now;
            }
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.SetValues(copyObj);

            if (mod == MOD.DODAVANJE)
            {
                try
                {
                    UplateDAO.Create(original);
                    Aplikacija.Instanca.Uplate.Add(original);
                    foreach (Ucenik u in Aplikacija.Instanca.Ucenici)
                    {
                        if (u.JMBG == original.Ucenik.JMBG)
                        {
                            u.Uplate.Add(original);
                        }
                    }
                }
                catch { }
            }
            else
            {
                UplateDAO.Update(original);
            }
            UplateDAO.Read();
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
