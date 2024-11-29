using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klasses_BedrAfd
{
    public class Afdeling
    {
        //Velden
        int _id = 0;
        string _afdNaam = null;
        string _afdHoofd = null;
        List<Medewerker> _medewerkers = new List<Medewerker>();

        // Properties
        public int PropId
        {
            get { return _id; }
        }

        public string PropAfdNaam
        {
            get { return _afdNaam; }
            set { _afdNaam = value; }
        }

        public string PropAfdHoofd
        {
            get { return _afdHoofd; }
            set { _afdHoofd = value; }
        }

        public List<Medewerker> PropMedewerker
        {
            get { return _medewerkers; }
            set { _medewerkers = value; }
        }

        // Methoden

        /// <summary>
        ///    Geeft een string terug met de namen 
        ///    van alle werknemers van deze afdeling onder elkaar
        /// </summary>
        /// <returns></returns>
        public string GetAlleMedewerkers()
        {
            string antwoord = "";

            foreach (Medewerker m in _medewerkers)
            {
                antwoord += m.VolledigeNaam() + " /n ";
            }

            return antwoord;
        }

        /// <summary>
        ///    Geeft de afdelingsnaam en de naam van het afdelingshoofd weer.
        /// </summary>
        /// <returns></returns>
        public string GetAfdNaamEnHoofd()
        {
            string antwoord = $"Afdelingsnaam: {_afdNaam} met aan het hoofd: {_afdHoofd}";
            return antwoord;
        }

        /// <summary>
        ///    Geeft een string terug:
        ///    de afdelingsnaam, de naam van het afdelingshoofdmet en
        ///    met de namen van alle werknemers van deze afdeling 
        /// </summary>
        /// <returns></returns>

        public string GetAlleGegevens()
        {
            string antwoord = GetAfdNaamEnHoofd();
            antwoord += $"\nmet volgende werknemers:\n {GetAlleMedewerkers()}";
            
            return antwoord;
        }

        //Constructors
         public Afdeling() { }

        public Afdeling(int ontvId, string ontvNaam, string ontvHoofd)
        {
            _id = ontvId;
            _afdNaam = ontvNaam;
            _afdHoofd = ontvHoofd;
        }

        public Afdeling(string ontvNaam, string ontvHoofd)
        {
            _afdNaam = ontvNaam;
            _afdHoofd = ontvHoofd;
        }


        public Afdeling(int ontvId, string ontvNaam, string ontvHoofd, List<Medewerker> ontvMedewerkers)
        {
            _id = ontvId;
            _afdNaam = ontvNaam;
            _afdHoofd = ontvHoofd;
            _medewerkers = ontvMedewerkers;

        }

        // onderstaande constructor is mogelijk, maar waarschijnlijk overbodig
        public Afdeling(string ontvNaam, string ontvHoofd, List<Medewerker> ontvMedewerkers)
        {
            _afdNaam = ontvNaam;
            _afdHoofd = ontvHoofd;
            _medewerkers = ontvMedewerkers;

        }
    }
}
