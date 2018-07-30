using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaConsole
{
    public class Uplata : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private Ucenik ucenik;

        public Ucenik Ucenik
        {
            get { return ucenik; }
            set { ucenik = value; OnPropertyChanged("Ucenik"); }
        }

        private double cena;

        public double Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }

        private Kurs kurs;

        public Kurs Kurs
        {
            get { return kurs; }
            set { kurs = value; OnPropertyChanged("Kurs"); }
        }

        private DateTime datum;

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; OnPropertyChanged("Datum"); }
        }
        
        

        public Uplata()
        {
            this.Datum = DateTime.Now;
        }

        public Uplata(Ucenik ucenik, double cena, Kurs kurs, DateTime datum)
        {
            this.Ucenik = ucenik;
            this.Cena = cena;
            this.Kurs = kurs;
            this.Datum = datum;
        }

        public override string ToString()
        {
            return "Ucenik: " + this.Ucenik.Ime + " " + this.Ucenik.Prezime + " Kurs: " + this.Kurs +
                " Cena: " + this.Cena;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void SetValues(Uplata copyObj)
        {
            this.Ucenik = copyObj.Ucenik;
            this.Kurs = copyObj.Kurs;
            this.Cena = copyObj.Cena;
            this.Datum = copyObj.Datum;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
