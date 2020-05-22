using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Voetbal_Library
{
    public class Transfer
    {
        public Transfer()
        {

        }
        public Transfer(Speler speler, double transferPrijs, Team oudTeam, Team nieuwTeam)
        {
            Speler = speler;
            TransferPrijs = transferPrijs;
            OudTeam = oudTeam;
            NieuwTeam = nieuwTeam;
        }
        public int Id { get; set; }
        public Speler Speler { get; set; }
        public double TransferPrijs { get; set; }
        public Team OudTeam { get; set; }
        public Team NieuwTeam { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Speler.Naam} ging van {OudTeam.Stamnummer} naar {NieuwTeam.Stamnummer} voor {TransferPrijs}euro";
        }

    }
}
