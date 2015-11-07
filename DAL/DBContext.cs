using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace NettButikk.DAL
{
    public class Brukere
    {
        [Key]
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }

        public virtual Brukerinformasjon BrukerInfo { get; set; }
    }

    public class Brukerinformasjon
    {
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Epost { get; set; }
        public string Brukernavn { get; set; }

        public virtual List<Ordrer> Ordrer { get; set; }
    }

    public class Betalingmetoder
    {
        public int ID { get; set; }
        public string Metode { get; set; }
    }

    public class Ordrer
    {
        public int ID { get; set; }
        public DateTime? Dato { get; set; }
        public string Betalt { get; set; }

        public virtual List<Produkter> Produkter { get; set; }
        public virtual Betalingmetoder Betalingsmetode { get; set; }
    }

    public class Produkter
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public int Pris { get; set; }
    }

    public class ButikkContext : DbContext
    {
        public ButikkContext()
            : base("name=ButikkDBString")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Brukere> Brukere { get; set; }
        public DbSet<Brukerinformasjon> Brukerinformasjon { get; set; }
        public DbSet<Betalingmetoder> Betalingmetoder { get; set; }
        public DbSet<Ordrer> Ordrer { get; set; }
        public DbSet<Produkter> Produkter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
