using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaConsole
{
    public class TipKursa : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private string nivo;

        public string Nivo
        {
            get { return nivo; }
            set
            {
                nivo = value;
                OnPropertyChanged("Nivo");
            }
        }

        public TipKursa()
        {

        }

        public TipKursa(string nivo)
        {
            this.Nivo = nivo;
        }

        public override string ToString()
        {
            return Nivo;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        internal void SetValues(TipKursa copyObj)
        {
            this.Nivo = copyObj.Nivo;
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
