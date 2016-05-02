using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Lab_5.Models
{
    public class TripContext : DbContext
    {
        public Microsoft.Data.Entity.DbSet<Lab_5.Models.Stop> Stops { get; set; }

        public Microsoft.Data.Entity.DbSet<Lab_5.Models.Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString =
               Startup.Configuration["Data:DefaultConnection:Server = (localdb)\\MSSQLLocalDB; Database = TripDB; Trusted_Connection = True; "];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
