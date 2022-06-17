using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Warehouse.Models;

namespace Warehouse.DAL
{
    public class MagazynContext : DbContext
    {
        public DbSet<Pracownik> Pracownik { get; set; }
        public DbSet<Dokument> Dokument { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Adres> Adres { get; set; }
        public DbSet<Pozycja> Pozycja { get; set; }
        public DbSet<Towar> Towar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}