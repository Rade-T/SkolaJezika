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
    /// Interaction logic for TipoviKursaEditWindow.xaml
    /// </summary>
    public partial class TipoviKursaEditWindow : Window
    {
        protected TipKursa original, copyObj;
        protected MOD mod;
        
        public TipoviKursaEditWindow()
        {
            InitializeComponent();
        }

        public TipoviKursaEditWindow(TipKursa t, MOD m = MOD.DODAVANJE) : this()
        {
            this.original = t;
            this.mod = m;
            this.copyObj = original.Clone() as TipKursa;
            this.DataContext = copyObj;
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.SetValues(copyObj);

            if (mod == MOD.DODAVANJE)
            {
                try
                {
                    Aplikacija.Instanca.TipoviKursa.Add(original);
                    TipKursaDAO.Create(original);
                }
                catch { }
            }
            else
            {
                try { TipKursaDAO.Update(original); }
                catch { }
            }
            TipKursaDAO.Read();
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
