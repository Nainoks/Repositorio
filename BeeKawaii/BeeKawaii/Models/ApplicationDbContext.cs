using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BeeKawaii.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :base ("BeeKawaii")
        {

        }
        public DbSet<Pupilentes> Pupilentes { get; set; }
        public DbSet<ProductoHechoAMano> ProductoHechoAMano { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}