namespace MCAPI.McWorld.Shared.Data
{
    using MCAPI.McWorld.Shared.Models;
    using Microsoft.EntityFrameworkCore;
    public class McDbContext : DbContext
    {
        public McDbContext(DbContextOptions<McDbContext> options) : base(options)
        {

        }

        //Tables in the Database
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Registration> Registration { get; set; }


        // we override the OnModelCreating method here.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasKey(ue => new { ue.UserID, ue.EventID });

            modelBuilder.Entity<Registration>()
            .HasOne(bc => bc.Event)
            .WithMany(b => b.Registration)
            .HasForeignKey(bc => bc.EventID);

            modelBuilder.Entity<Registration>()
            .HasOne(bc => bc.User)
            .WithMany(c => c.Registration)
            .HasForeignKey(bc => bc.UserID);

            modelBuilder.Entity<Route>()
                .HasOne(a => a.Address)
                .WithMany(r => r.Routes);

            modelBuilder.Entity<Route>()
               .HasOne(u => u.User)
               .WithMany(r => r.Routes);

            modelBuilder.Entity<Event>()
               .HasOne(u => u.User)
               .WithMany(r => r.Events);

            modelBuilder.Entity<Event>()
               .HasOne(r => r.Route)
               .WithMany(e => e.Events);
        }
    }
}
