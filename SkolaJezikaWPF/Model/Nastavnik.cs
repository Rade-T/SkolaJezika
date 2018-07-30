using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaConsole
{
    public class Nastavnik : Osoba
    {
        public long Id { get; set; }

        private ObservableCollection<Ucenik> ucenici;

        public ObservableCollection<Ucenik> Ucenici
        {
            get { return ucenici; }
            set 
            { 
                ucenici = value; 
                OnPropertyChanged("Ucenici");
            }
        }

        private ObservableCollection<Kurs> kursevi;

        public ObservableCollection<Kurs> Kursevi
        {
            get { return kursevi; }
            set 
            {
                kursevi = value;
                OnPropertyChanged("Kursevi");
            }
        }
        
        public String ImePrezime
        {
            get { return Ime + " " + Prezime; }
        }

        public Nastavnik()
        {
            this.Kursevi = new ObservableCollection<Kurs>();
            this.Ucenici = new ObservableCollection<Ucenik>();
        }

        public Nastavnik(string ime, string prezime, string jmbg, DateTime datum) : base(ime, prezime, jmbg, datum)
        {
            this.Kursevi = new ObservableCollection<Kurs>();
            this.Ucenici = new ObservableCollection<Ucenik>();
        }

        public Nastavnik(string ime, string prezime, string jmbg)
            : base(ime, prezime, jmbg)
        {
            this.Kursevi = new ObservableCollection<Kurs>();
            this.Ucenici = new ObservableCollection<Ucenik>();
        }

        public Nastavnik(string ime, string prezime, string jmbg, DateTime datum, ObservableCollection<Ucenik> ucenici, ObservableCollection<Kurs> kursevi) : base(ime, prezime, jmbg, datum)
        {
            this.Kursevi = kursevi;
            this.Ucenici = ucenici;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void setValues(Nastavnik copyObj)
        {
            this.Ime = copyObj.Ime;
            this.Prezime = copyObj.Prezime;
            this.JMBG = copyObj.JMBG;
            this.Ucenici = copyObj.ucenici;
            this.Kursevi = copyObj.kursevi;
        }
    }
}
