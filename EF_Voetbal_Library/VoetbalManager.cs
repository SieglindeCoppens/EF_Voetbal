using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EF_Voetbal_Library
{
    public class VoetbalManager
    {
        private VoetbalContext ctx = new VoetbalContext();
        public void InitialiseerDatabank(string path)
        {
            List<Team> teams = new List<Team>();
            using(StreamReader r = new StreamReader(path))
            {
                string line;
                string naam;
                int nummer;
                string club;
                int waarde;
                int stamnummer;
                string trainer;
                string bijnaam;
                r.ReadLine();
                while((line = r.ReadLine()) != null)
                {
                    string[] ss = line.Split(",").Select(x => x.Trim()).ToArray();
                    naam = ss[0];
                    nummer = int.Parse(ss[1]);
                    club = ss[2];
                    waarde = int.Parse(ss[3].Replace(" ",String.Empty));
                    stamnummer = int.Parse(ss[4]);
                    trainer = ss[5];
                    bijnaam = ss[6];

                    Team team = new Team(stamnummer, club, bijnaam, trainer);
                    Speler speler = new Speler(naam, nummer, waarde);

                    if (!teams.Contains(team))
                    {
                        team.Spelers.Add(speler);
                        teams.Add(team);
                    }
                    else
                    {
                        List<Team> teamR = teams.Where(t => t.Equals(team)).ToList();
                        teamR[0].Spelers.Add(speler);
                    }
                }
            }
            using (ctx)
            {
                ctx.Teams.AddRange(teams);
                ctx.SaveChanges();
            }
        }
        public void VoegSpelerToe(Speler speler)
        {
            ctx.Spelers.Add(speler);
            ctx.SaveChanges();
        }
        public void VoegTeamToe(Team team)
        {
            ctx.Teams.Add(team);
            ctx.SaveChanges();
        }
        public void VoegTransferToe(Transfer transfer)
        {
            ctx.Transfers.Add(transfer);
            transfer.Speler.Team = transfer.NieuwTeam;
            UpdateSpeler(transfer.Speler);
        }
        public void UpdateSpeler(Speler speler)
        {
            Speler teUpdatenSpeler = ctx.Spelers.Single(x => x.Naam == speler.Naam);
            teUpdatenSpeler.Rugnummer = speler.Rugnummer;
            teUpdatenSpeler.Waarde = speler.Waarde;
            if (!(speler.Team == null))
            {
                teUpdatenSpeler.Team = speler.Team;
            }
            ctx.SaveChanges();
        }
        public void UpdateTeam(Team team)
        {
            Team teUpdatenTeam = ctx.Teams.Single(x => x.Stamnummer == team.Stamnummer);
            teUpdatenTeam.Trainer = team.Trainer;
            teUpdatenTeam.Naam = team.Naam;
            teUpdatenTeam.Bijnaam = team.Bijnaam;
            ctx.SaveChanges();
        }
        public Speler SelecteerSpeler(int spelerID)
        {
            Speler speler = ctx.Spelers
                .Include(s=>s.Team)
                .Single(s => s.SpelerID == spelerID);
            return speler;
        }
        public Team SelecteerTeam(int stamnummer)
        {
            Team team = ctx.Teams
                .Include(t=> t.Spelers)
                .Single(t => t.Stamnummer == stamnummer);
            return team;
        }
        public Transfer SelecteerTransfer(int transferID)
        {
            var transfer = ctx.Transfers
                .Include(t=>t.Speler)
                .Include(t => t.OudTeam)
                .Include(t => t.NieuwTeam)
                .Single(t => t.Id == transferID);
            return transfer;
        }
    }
}
