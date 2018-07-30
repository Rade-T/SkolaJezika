using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaWPF.Model
{
    public class Skola : INotifyPropertyChanged
    {
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

        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set 
            { 
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        private string telefon;

        public string Telefon
        {
            get { return telefon; }
            set 
            { 
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string internetAdresa;

        public string InternetAdresa
        {
            get { return internetAdresa; }
            set 
            { 
                internetAdresa = value;
                OnPropertyChanged("InternetAdresa");
            }
        }

        private string pib;

        public string PIB
        {
            get { return pib; }
            set 
            { 
                pib = value;
                OnPropertyChanged("PIB");
            }
        }

        private string maticniBroj;

        public string MaticniBroj
        {
            get { return maticniBroj; }
            set 
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }

        private string ziroRacun;

        public string ZiroRacun
        {
            get { return ziroRacun; }
            set
            { 
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
            }
        }

        public override string ToString()
        {
            return this.Naziv + " " + this.Adresa;
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void setValues(Skola copyObj)
        {
            this.Naziv = copyObj.Naziv;
            this.Adresa = copyObj.Adresa;
            this.InternetAdresa = copyObj.InternetAdresa;
            this.MaticniBroj = copyObj.MaticniBroj;
            this.Telefon = copyObj.Telefon;
            this.ZiroRacun = copyObj.ZiroRacun;
            this.PIB = copyObj.PIB;
            this.Email = copyObj.Email;
        }
    }
}
