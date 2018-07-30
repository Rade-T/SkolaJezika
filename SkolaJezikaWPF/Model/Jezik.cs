using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaConsole
{
    public class Jezik : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set 
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        private string oznaka;

        public string Oznaka
        {
            get { return oznaka; }
            set
            { 
                oznaka = value;
                OnPropertyChanged("Oznaka");
            }
        }
        
        
        public bool Obrisan { get; set; }

        public Jezik()
        {

        }

        public Jezik(string naziv, string oznaka)
        {
            this.Naziv = naziv;
            this.Oznaka = oznaka;
            this.Obrisan = false;
        }

        public override string ToString()
        {
            return "Naziv: " + this.Naziv + " Oznaka: " + this.Oznaka;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void setValues(Jezik copyObj)
        {
            this.Naziv = copyObj.Naziv;
            this.Oznaka = copyObj.Oznaka;
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
