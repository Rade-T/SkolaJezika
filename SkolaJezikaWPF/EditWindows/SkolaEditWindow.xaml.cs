using SkolaJezikaWPF.DAO;
using SkolaJezikaWPF.Model;
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

namespace SkolaJezikaWPF.EditWindows
{
    /// <summary>
    /// Interaction logic for SkolaEditWindow.xaml
    /// </summary>
    public partial class SkolaEditWindow : Window
    {
        protected Skola original, copyObj;

        public SkolaEditWindow()
        {
            InitializeComponent();
        }

        public SkolaEditWindow(Skola s) : this()
        {
            this.original = s;
            this.copyObj = original.Clone() as Skola;
            this.DataContext = copyObj;
        }

        private void bSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            this.original.setValues(copyObj);
            {
                try { SkolaDAO.Update(original); }
                catch { }
            }
            SkolaDAO.Read();
            this.DialogResult = true;
            this.Close();
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
