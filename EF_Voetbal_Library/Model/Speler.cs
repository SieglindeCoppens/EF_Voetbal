
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Voetbal_Library
{
    public class Speler
    {
        public Speler(string naam, int rugnummer, double waarde)
        {
            Naam = naam;
            Rugnummer = rugnummer;
            Waarde = waarde;
        }

        public Speler(string naam, int rugnummer, double waarde, Team team)
        {
            Team = team;
            Naam = naam;
            Rugnummer = rugnummer;
            Waarde = waarde;

        }
        public int SpelerID { get; set; }
        public string Naam { get; set; }
        public int Rugnummer { get; set; }
        public double Waarde { get; set; }

        public Team Team { get; set; } //?? beide??
        //public int Stamnummer { get; set; } // of moet ik hiervan team maken??

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Speler p = (Speler)obj;
                return (Naam == p.Naam);
            }
        }
        public override int GetHashCode()
        {
            return SpelerID.GetHashCode() ^ Naam.GetHashCode();
        }
        public override string ToString()
        {
            if(Team == null)
            {
                return $"{SpelerID} : {Naam} met rugnr {Rugnummer} is {Waarde}euro waard en speelt momenteel niet bij een team";
            }

            return $"{SpelerID} : {Naam} met rugnr {Rugnummer} is {Waarde}euro waard en speelt bij {Team.Naam}";
        }
    }
}
