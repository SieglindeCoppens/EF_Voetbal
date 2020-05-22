using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace EF_Voetbal_Library
{
    public class VoetbalContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HT91N8R\\SQLEXPRESS;Initial Catalog=db_Voetbal;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
