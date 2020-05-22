using System;
using EF_Voetbal_Library;

namespace EF_Voetbal_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            VoetbalManager vdb = new VoetbalManager();

            //vdb.InitialiseerDatabank(@"C:\Users\Sieglinde\OneDrive\Documenten\Programmeren\semester2\programmeren 4\foot.csv");

            //Team team = new Team(33, "Rode duivels", "duveltjes", "meneer de trainer");
            //vdb.VoegSpelerToe(sUppeler);

            //Team team = new Team(33, "Witte engels", "engeltjes", "meneer de trainer");
            //vdb.UpdateTeam(team);

            //Team team = new Team(13, "Saaie voetballers", "Saaierds", "mevr. haatsprt");
            //vdb.VoegTeamToe(team);

            //Speler speler = new Speler("Teamloze armerd", 1, 5);
            //vdb.UpdateSpeler(speler);

            Speler speler = vdb.SelecteerSpeler(10);
            Console.WriteLine(speler);

            //Team nieuwTeam = vdb.SelecteerTeam(33);
            //Team oudTeam = vdb.SelecteerTeam(7);

            //Team team = vdb.SelecteerTeam(7);
            //Console.WriteLine(team);

            //Transfer transfer = new Transfer(speler, speler.Waarde, oudTeam, nieuwTeam);
            //vdb.VoegTransferToe(transfer);
            //Transfer transfer = vdb.SelecteerTransfer(1);
            //Console.WriteLine(transfer);
        }
    }
}
