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
    /// Interaction logic for JeziciEditWindow.xaml
    /// </summary>
    public partial class JeziciEditWindow : Window
    {
        protected Jezik original, copyObj;
        protected MOD mod;

        public JeziciEditWindow()
        {
            InitializeComponent();
        }

        public JeziciEditWindow(Jezik j, MOD m = MOD.DODAVANJE) : this()
        {
            this.original = j;
            this.mod = m;
            this.copyObj = original.Clone() as Jezik;
            this.DataContext = copyObj;
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.setValues(copyObj);

            if (mod == MOD.DODAVANJE)
            {
                try
                {
                    Aplikacija.Instanca.Jezici.Add(original);
                    JezikDAO.Create(original);
                }
                catch
                {

                }
            }
            else
            {
                try { JezikDAO.Update(original); }
                catch { }
            }
            JezikDAO.Read();
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
