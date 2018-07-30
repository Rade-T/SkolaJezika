using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezikaConsole;
using System.Collections.ObjectModel;
using SkolaJezikaWPF.DAO;
using SkolaJezikaWPF.Model;

namespace SkolaJezikaWPF
{
    public class Aplikacija
    {
        public const string PARK_STR = @"data source=.\SQLEXPRESS;
                                        initial catalog=SkolaJezika2;
                                        integrated security=true";
        public const string HOME_STR = @"data source=RADE-PC\SQLEXPRESS;
                                        initial catalog=SkolaJezika2;
                                        integrated security=true";
        public const string CONN_STR = HOME_STR;
        public ObservableCollection<TipKorisnika> TipoviKorisnika { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Nastavnik> Nastavnici { get; set; }
        public ObservableCollection<Ucenik> Ucenici { get; set; }
        public ObservableCollection<Jezik> Jezici { get; set; }
        public ObservableCollection<TipKursa> TipoviKursa { get; set; }
        public ObservableCollection<Kurs> Kursevi { get; set; }
        public ObservableCollection<Uplata> Uplate { get; set; }
        public Skola Skola { get; set; }

        private static Aplikacija instanca = new Aplikacija();

        public static Aplikacija Instanca
        {
            get { return instanca; }
        }

        private Aplikacija()
        {
            Korisnici = new ObservableCollection<Korisnik>();
            TipoviKorisnika = new ObservableCollection<TipKorisnika>();
            Ucenici = new ObservableCollection<Ucenik>();
            Nastavnici = new ObservableCollection<Nastavnik>();
            Jezici = new ObservableCollection<Jezik>();
            TipoviKursa = new ObservableCollection<TipKursa>();
            Kursevi = new ObservableCollection<Kurs>();
            Uplate = new ObservableCollection<Uplata>();
        }

        private void UcitajKorisnike()
        {
            TipoviKorisnika.Add(new TipKorisnika("admin", "administrira sve entitete aplikacije"));
            TipoviKorisnika.Add(new TipKorisnika("radnik", "ima pristup kursevima, uplatama i ucenicima"));
            Korisnik k = new Korisnik("Marko", "Markovic", "123", new DateTime(1996, 1, 1), "m", "m", TipoviKorisnika[0]);
            Korisnici.Add(k);
            Korisnici.Add(new Korisnik("Janko", "Jankovic", "321", new DateTime(1996, 12, 31), "j", "j", TipoviKorisnika[1]));
            Korisnici.Add(new Korisnik("Milan", "Mitrovic", "333", new DateTime(1996, 6, 6), "mm", "mm", TipoviKorisnika[1]));
            Korisnici.Add(new Korisnik("Petar", "Petrovic", "444", new DateTime(1996, 1, 2), "p", "p", TipoviKorisnika[1]));
        }

        public TipKorisnika GetByID(long id)
        {
            TipKorisnika retVal = null;
            foreach (TipKorisnika t in this.TipoviKorisnika)
            {
                if (t.Id == id)
                {
                    retVal = t;
                    break;
                }
            }

            return retVal;
        }

        public Kurs GetKursByID(long id)
        {
            Kurs retVal = null;
            foreach (Kurs k in this.Kursevi)
            {
                if (k.Id == id)
                {
                    retVal = k;
                    break;
                }
            }

            return retVal;
        }

        /*
        public Nastavnik GetNastavnikByID(long id)
        {
            Nastavnik retVal = null;
            foreach (Nastavnik k in this.Nastavnici)
            {
                if (k.Id == id)
                {
                    retVal = k;
                    break;
                }
            }

            return retVal;
        }*/

        private void UcitajNastavnike()
        {
            Nastavnici.Add(new Nastavnik("Pera", "Peric", "1234"));
            Nastavnici.Add(new Nastavnik("Mika", "Mikic", "2222"));
        }

        private void UcitajUcenike()
        {
            Ucenici.Add(new Ucenik("a", "a", "1"));
            Ucenici.Add(new Ucenik("b", "b", "2"));
            Ucenici.Add(new Ucenik("c", "c", "3"));
            Ucenici.Add(new Ucenik("d", "d", "4"));
            UcenikDAO.Read();
        }

        private void UcitajJezike()
        {
            Jezici.Add(new Jezik("Engleski", "ENG"));
            Jezici.Add(new Jezik("Nemacki", "GER"));
            Jezici.Add(new Jezik("Spanski", "ESP"));
        }

        private void UcitajTipoveKursa()
        {
            TipoviKursa.Add(new TipKursa("Osnovni"));
            TipoviKursa.Add(new TipKursa("Srednji"));
            TipoviKursa.Add(new TipKursa("Napredni"));
        }

        private void UcitajKurseve()
        {
            Kursevi.Add(new Kurs(Jezici[0], TipoviKursa[0], 1000, Nastavnici[0], new ObservableCollection<Ucenik>() {Ucenici[0], Ucenici[1], Ucenici[2]}));
            Kursevi.Add(new Kurs(Jezici[1], TipoviKursa[1], 2000, Nastavnici[1], new ObservableCollection<Ucenik>() { Ucenici[2], Ucenici[1], Ucenici[0] }));
        }

        private void UcitajUplate()
        {
            Uplate.Add(new Uplata(Ucenici[0], 1200, Kursevi[0], new DateTime(2016, 12, 11)));
            Uplate.Add(new Uplata(Ucenici[1], 1200, Kursevi[1], new DateTime(2016, 12, 10)));
        }
    }
}
