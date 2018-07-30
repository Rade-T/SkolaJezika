using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaConsole
{
    public class Kurs : ICloneable, INotifyPropertyChanged
    {
        public long Id { get; set; }
        public string Naziv { get; set; }

        private Jezik jezikKursa;

        public Jezik JezikKursa
        {
            get { return jezikKursa; }
            set 
            { 
                jezikKursa = value;
                OnPropertyChanged("JezikKursa");
            }
        }

        private TipKursa tipKursa;

        public TipKursa Tip
        {
            get { return tipKursa; }
            set { tipKursa = value; OnPropertyChanged("Tip"); }
        }

        private double cena;

        public double Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged("Cena"); }
        }

        private Nastavnik predavac;

        public Nastavnik Predavac
        {
            get { return predavac; }
            set { predavac = value; OnPropertyChanged("Predavac"); }
        }

        private ObservableCollection<Ucenik> ucenici;

        public ObservableCollection<Ucenik> Ucenici
        {
            get { return ucenici; }
            set { ucenici = value; OnPropertyChanged("Ucenici"); }
        }
        
        
        public bool Obrisan { get; set; }

        public Kurs()
        {
            this.Ucenici = new ObservableCollection<Ucenik>();
        }

        public Kurs(Jezik jezik, TipKursa tip, double cena, Nastavnik predavac, ObservableCollection<Ucenik> ucenici)
        {
            this.JezikKursa = jezik;
            this.Tip = tip;
            this.Cena = cena;
            this.Predavac = predavac;
            this.Ucenici = ucenici;
            this.Obrisan = false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void SetValues(Kurs copyObj)
        {
            this.JezikKursa = copyObj.JezikKursa;
            this.Tip = copyObj.Tip;
            this.Predavac = copyObj.Predavac;
            this.Cena = copyObj.Cena;
            this.Ucenici = copyObj.Ucenici;
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

        public override string ToString()
        {
            return this.JezikKursa.Naziv + " " + this.Tip.Nivo;
        }
    }
}
