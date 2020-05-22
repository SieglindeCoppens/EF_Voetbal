using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_Voetbal_Library
{
    public class Team
    {
        public Team(int stamnummer, string naam, string bijnaam, string trainer)
        {
            Stamnummer = stamnummer;
            Naam = naam;
            Bijnaam = bijnaam;
            Trainer = trainer;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stamnummer { get; set; }
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }
        public List<Speler> Spelers { get; set; } = new List<Speler>();

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Team p = (Team)obj;
                return (Stamnummer == p.Stamnummer);
            }
        }
        public override int GetHashCode()
        {
            return Stamnummer.GetHashCode() ^Naam.GetHashCode();
        }
        public override string ToString()
        {
            string spelers = "";
            foreach(Speler s in Spelers)
            {
                spelers += $" {s.Naam} ";
            }
            
            return $"{Stamnummer}: {Naam} ({Bijnaam}) \n met trainer: {Trainer} \n met spelers : {spelers}";
            
        }

    }
}
