using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SkolaJezikaWPF.DAO;
using SkolaJezikaConsole;

namespace SkolaJezikaWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            UcenikDAO.Read();
            TipKorisnikaDAO.Read();
            KorisnikDAO.Read();
            NastavnikDAO.Read();
            JezikDAO.Read();
            TipKursaDAO.Read();
            KursDAO.Read();
            UplateDAO.Read();
        }

        private void KurseviTest()
        {
            foreach (Kurs k in Aplikacija.Instanca.Kursevi)
            {
                Console.Write("Kurs: " + k.Naziv + "Ucenici:\n");
                foreach (Ucenik u in k.Ucenici)
                {
                    Console.WriteLine(u.Ime + " " + u.Id);
                }
                Console.WriteLine();
            }
        }
    }
}
