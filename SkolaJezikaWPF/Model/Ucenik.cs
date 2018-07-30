using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaConsole
{
    public class Ucenik : Osoba, ICloneable, INotifyPropertyChanged
    {
        public long Id { get; set; }

        public string ImePrezime
        {
            get { return Ime + " " + Prezime; }
        }

        private ObservableCollection<Kurs> kursevi;

        public ObservableCollection<Kurs> Kursevi
        {
            get { return kursevi; }
            set { kursevi = value; }
        }

        private ObservableCollection<Uplata> uplate;

        public ObservableCollection<Uplata> Uplate
        {
            get { return uplate; }
            set { uplate = value; }
        }

        public Ucenik()
        {
            this.Kursevi = new ObservableCollection<Kurs>();
            this.Uplate = new ObservableCollection<Uplata>();
        }

        public Ucenik(string ime, string prezime, string jmbg, DateTime datum) : base(ime, prezime, jmbg, datum)
        {
            Kursevi = new ObservableCollection<Kurs>();
            Uplate = new ObservableCollection<Uplata>();
        }

        public Ucenik(string ime, string prezime, string jmbg)
            : base(ime, prezime, jmbg)
        {
            Kursevi = new ObservableCollection<Kurs>();
            Uplate = new ObservableCollection<Uplata>();
        }

        public Ucenik(string ime, string prezime, string jmbg, DateTime datum, ObservableCollection<Kurs> kursevi, ObservableCollection<Uplata> uplate) : base(ime, prezime, jmbg, datum)
        {
            Uplate = uplate;
            Kursevi = kursevi;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void SetValues(Ucenik copyObj)
        {
            this.Ime = copyObj.Ime;
            this.Prezime = copyObj.Prezime;
            this.JMBG = copyObj.JMBG;
        }
    }
}
