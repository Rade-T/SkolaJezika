using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaConsole
{
    public class Osoba : INotifyPropertyChanged
    {
        private string ime;

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        private string jmbg;

        public string JMBG
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged("JMBG");
            }
        }

        private string prezime;
        public bool Obrisan { get; set; }

	    public string Prezime
	    {
		    get { return prezime;}
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
	    }

        private DateTime datumRodjenja;

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                datumRodjenja = value;
                OnPropertyChanged("DatumRodjenja");
            }
        }
        

        public Osoba()
        {
            this.DatumRodjenja = DateTime.Now;
        }

        public Osoba(string ime, string prezime, string jmbg)
        {
            this.Ime = ime;
            this.prezime = prezime;
            this.JMBG = jmbg;
            this.Obrisan = false;
        }

        public Osoba(string ime, string prezime, string jmbg, DateTime datum)
        {
            this.Ime = ime;
            this.prezime = prezime;
            this.JMBG = jmbg;
            this.DatumRodjenja = datum;
            this.Obrisan = false;
        }

        public override string ToString()
        {
            return "Ime: " + this.Ime + " Prezime: " + this.prezime + " JMBG: " + this.JMBG;
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
