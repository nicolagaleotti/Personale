using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inserimento_Personale
{
    public class Persona
    {
        public string CodiceFiscale { get; private set; }
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public string Tipologia { get; private set; }
        public string Qualifica { get; set; }
        public string Area { get; set; }

        public Persona(string cf, string nome, string cognome, int tipologia)
        {
            CodiceFiscale = cf;
            Nome = nome;
            Cognome = cognome;
            if (tipologia == 0)
                Tipologia = "Aziendale";
            if (tipologia == 0)
                Tipologia = "SubFornitore";
            if (tipologia == 0)
                Tipologia = "Fornitore";
            if (tipologia == 0)
                Tipologia = "Consulente";
        }

        public string Descrizione()
        {
            return $"{CodiceFiscale}, {Nome} {Cognome}, {Tipologia}, {Qualifica}, {Area}.";
        }
    }
}
