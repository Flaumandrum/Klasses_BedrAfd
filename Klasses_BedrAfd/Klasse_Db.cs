using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Klasses_BedrAfd
{
    public class Klasse_Db
    {
        // velden
        static String _pad = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\TomAdriaens\OneDrive - Oscar Romerocollege\Informatica 5AD 6AD\6AD\Databases\Proj_Bedrijfsafdeling.accdb";
        OleDbConnection _mijnConn = new OleDbConnection(_pad);

        // Properties

        // Methoden 
        public List<Medewerker> VraagMWop()
        {
            List<Medewerker> antwoord = new List<Medewerker>();
            string sql = "SELECT Id, Voornaam, Achternaam, IdAfdeling FROM Medewerker";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);
            OleDbDataReader mijnReader;

            _mijnConn.Open();

            mijnReader = mijnCommando.ExecuteReader();

            while (mijnReader.Read())
            {
                int ontvId = Convert.ToInt32(mijnReader["Id"]);
                string ontvVn = Convert.ToString(mijnReader["Voornaam"]);
                string ontvAn = Convert.ToString(mijnReader["Achternaam"]);
                int ontvIdAfd = Convert.ToInt32(mijnReader["IdAfdeling"]);
                Afdeling ontvAfdeling = VraagJuisteAfdOp(ontvIdAfd);

                Medewerker nieuweMw = new Medewerker(ontvId, ontvVn, ontvAn, ontvAfdeling);

                antwoord.Add(nieuweMw);

                
            }


            _mijnConn.Close();

            return antwoord;
        }

        public Afdeling VraagJuisteAfdOp(int ontvId)
        {
            Afdeling antwoord = new Afdeling();

            string sql = $"SELECT Id, Afdelingsnaam, Afdelingshoofd FROM Afdeling WHERE Id = {Convert.ToString(ontvId)}";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);
            OleDbDataReader mijnReader;

            

            mijnReader = mijnCommando.ExecuteReader();

            while (mijnReader.Read())
            {
                int Id = Convert.ToInt32(mijnReader["Id"]);
                string ontvAfdNaam = Convert.ToString(mijnReader["Afdelingsnaam"]);
                string ontvAfdHoofd = Convert.ToString(mijnReader["Afdelingshoofd"]);

                antwoord = new Afdeling(Id, ontvAfdNaam, ontvAfdHoofd);

            }

            return antwoord;
        }

        public List<Afdeling> VraagAfdOp()
        {
            List<Afdeling> antwoord = new List<Afdeling>();
                       
            string sql = "SELECT Id, Afdelingsnaam, Afdelingshoofd FROM Afdeling";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);
            OleDbDataReader mijnReader;

            _mijnConn.Open();

            mijnReader = mijnCommando.ExecuteReader();

            while (mijnReader.Read())
            {
                int ontvId = Convert.ToInt32(mijnReader["Id"]);
                string ontvAfdNaam = Convert.ToString(mijnReader["Afdelingsnaam"]);
                string ontvAfdHoofd = Convert.ToString(mijnReader["Afdelingshoofd"]);

                List<Medewerker> ontvLijstMw = VraagAlleMWVanAfdOp(ontvId);

                Afdeling nieuweAfd = new Afdeling(ontvId, ontvAfdNaam, ontvAfdHoofd, ontvLijstMw);

                antwoord.Add(nieuweAfd);


            }


            _mijnConn.Close();

            return antwoord;
        }

        public List<Medewerker> VraagAlleMWVanAfdOp(int ontvId)
        {
            List<Medewerker> antwoord = new List<Medewerker>();
            string sql = $"SELECT Id, Voornaam, Achternaam FROM Medewerker WHERE IdAfdeling = {Convert.ToString(ontvId)}";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);
            OleDbDataReader mijnReader;



            mijnReader = mijnCommando.ExecuteReader();

            while (mijnReader.Read())
            {
                int id = Convert.ToInt32(mijnReader["Id"]);
                string ontvVn = Convert.ToString(mijnReader["Voornaam"]);
                string ontvAn = Convert.ToString(mijnReader["Achternaam"]);
                
                Medewerker nieuweMW = new Medewerker(id, ontvVn, ontvAn);

                antwoord.Add(nieuweMW);

            }



            return antwoord;
        }

        /// <summary>
        /// Voegt de gegevens van de werknemer toe aan de database.
        /// </summary>
        /// <param name="ontvMw"></param>
        public void ToevoegenMW(Medewerker ontvMw)
        {

            string vn = ontvMw.PropVoornaam;
            string an = ontvMw.PropAchternaam;
            Afdeling afdWn = ontvMw.PropAfdeling;
            int idAfd = afdWn.PropId;

            string sql = $"INSERT INTO Medewerker (Voornaam, Achternaam, IdAfdeling) VALUES('{vn}', '{ an}',{Convert.ToString(idAfd)})";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);

            _mijnConn.Open();


            mijnCommando.ExecuteNonQuery();


            _mijnConn.Close();
        }

        public void AanpassenMw(Medewerker ontvMw)
        {
            int id = ontvMw.PropId;
            string vn = ontvMw.PropVoornaam;
            string an = ontvMw.PropAchternaam;
            Afdeling afdWn = ontvMw.PropAfdeling;
            int idAfd = afdWn.PropId;

            string sql = $"UPDATE Medewerker SET Voornaam = '{vn}' , Achternaam = '{ an}', IdAfdeling = {Convert.ToString(idAfd)} WHERE Id = {Convert.ToString(id)}";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);

            _mijnConn.Open();


            mijnCommando.ExecuteNonQuery();


            _mijnConn.Close();
        }

        public void VerwijdersnMw(Medewerker ontvMw)
        {

            int id = ontvMw.PropId;
            

            string sql = $"DELETE FROM Medewerker WHERE Id =  {Convert.ToString(id)} ";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);

            _mijnConn.Open();

            mijnCommando.ExecuteNonQuery();

            _mijnConn.Close();
        }

        /// <summary>
        /// Voegt de gegevens van de afdeling toe aan de database.
        /// </summary>
        /// <param name="ontvAfd"></param>
        public void ToevoegenAfd(Afdeling ontvAfd)
        {
            
            string afdNm = ontvAfd.PropAfdNaam;
            string afdHoofd = ontvAfd.PropAfdHoofd;

            string sql = $"INSERT INTO Afdeling (Afdelingsnaam, Afdelingshoofd) VALUES ('{afdNm}', '{afdHoofd}')";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);
            _mijnConn.Open();

            mijnCommando.ExecuteNonQuery();

            _mijnConn.Close();
        }

        public void AanpassenAfd(Afdeling ontvAfd)
        {
            int id = ontvAfd.PropId;
            string afdNm = ontvAfd.PropAfdNaam;
            string afdHoofd = ontvAfd.PropAfdHoofd;
            
            string sql = $"UPDATE Afdeling SET Afdelingsnaam = '{afdNm}' , Afdelingshoofd = '{afdHoofd}'WHERE Id = {Convert.ToString(id)} ";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);

            _mijnConn.Open();


            mijnCommando.ExecuteNonQuery();


            _mijnConn.Close();
        }

        public void VerwijdersnAfd(Afdeling ontvAfd)
        {
            int id = ontvAfd.PropId;

            string sql = $"DELETE FROM Afdeling WHERE Id = {Convert.ToString(id)} ";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _mijnConn);

            _mijnConn.Open();


            mijnCommando.ExecuteNonQuery();


            _mijnConn.Close();
        }

        // Constructor
        public Klasse_Db () { }
    }
}
