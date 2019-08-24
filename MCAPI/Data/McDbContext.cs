using MCAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCAPI.McContext
{
    public class McDbContext : DbContext
    {
        public McDbContext(DbContextOptions<McDbContext> options) : base(options)
        {
            
        }

        //Tables in the Database
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Registration> Registration { get; set; }


        // we override the OnModelCreating method here.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasKey(ue => new { ue.UserID , ue.EventID});
        }
    }
}
