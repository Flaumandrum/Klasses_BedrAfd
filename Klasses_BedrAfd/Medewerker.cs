using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Klasses_BedrAfd
{
    public class Medewerker
    {
        //Velden
        int _id = 0;
        string _voornaam = "";
        string _achternaam = "";
        Afdeling _afdeling = new Afdeling();


        // Properties
        public int PropId
        {
            get { return _id; }
        }

        public string PropVoornaam
        {
            get { return _voornaam; }
            set { _voornaam = value; }
        }

        public string PropAchternaam
        {
            get { return _achternaam; }
            set { _achternaam = value; }
        }

        public Afdeling PropAfdeling
        {
            get { return _afdeling; }
            set { _afdeling = value; }
        }

        // Methoden

        /// <summary>
        ///     Geeft de volledige naam weer van de werknemer
        /// </summary>
        /// <returns></returns>
        public string VolledigeNaam()
        {
            string antwoord = $" Naam: {_voornaam} {_achternaam}";
            return antwoord;
        }

        /// <summary>
        ///     Geeft de naam en het afdelingshoofd weer van de afdeling waar de werknemer werkzaam is
        /// </summary>
        /// <returns></returns>
        public string GetAfdeling()
        {
            string antwoord = "";

            antwoord = _afdeling.GetAfdNaamEnHoofd();

            return antwoord;
        }

        public string AlleGegevens()
        {
            string antwoord = "";

            antwoord = $"{VolledigeNaam()} \nWerkt in volgende afdeling: \n{_afdeling.GetAfdNaamEnHoofd()}";

            return antwoord;
        }


        //Constructors
        public Medewerker() { }
        public Medewerker(int ontvId, string ontvVn, string ontvAn) 
        {
            _id = ontvId;
            _voornaam = ontvVn;
            _achternaam = ontvAn;
        }

        public Medewerker(string ontvVn, string ontvAn, Afdeling _ontvAfd)
        {
            _voornaam = ontvVn;
            _achternaam = ontvAn;
            _afdeling = _ontvAfd;
        }

        public Medewerker(int ontvId, string ontvVn, string ontvAn, Afdeling _ontvAfd)
        {
            _id = ontvId;
            _voornaam = ontvVn;
            _achternaam = ontvAn;
            _afdeling = _ontvAfd;
        }

    }
}
