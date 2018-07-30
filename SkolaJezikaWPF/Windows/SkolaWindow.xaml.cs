using SkolaJezikaWPF.DAO;
using SkolaJezikaWPF.EditWindows;
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

namespace SkolaJezikaWPF.Windows
{
    /// <summary>
    /// Interaction logic for SkolaWindow.xaml
    /// </summary>
    public partial class SkolaWindow : Window
    {
        public SkolaWindow()
        {
            SkolaDAO.Read();
            InitializeComponent();
            this.DataContext = Aplikacija.Instanca.Skola;
        }

        private void bZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Skola s = Aplikacija.Instanca.Skola;
            SkolaEditWindow sew = new SkolaEditWindow(s);
            sew.ShowDialog();
        }
    }
}
