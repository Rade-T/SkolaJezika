using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaConsole
{
    public class TipKorisnika
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public TipKorisnika()
        {

        }

        public TipKorisnika(string naziv, string opis)
        {
            this.Naziv = naziv;
            this.Opis = opis;
        }

        public override string ToString()
        {
            return "Naziv: " + this.Naziv + " Opis: " + this.Opis;
        }
    }
}
