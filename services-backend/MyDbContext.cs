namespace services_backend
{
    using Microsoft.EntityFrameworkCore;
    using services_backend.Models;

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TypeService> TypeServices { get; set; }
        public DbSet<Time> Times { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Establishment)
                .WithMany(e => e.Clients)
                .HasForeignKey(c => c.EstablishmentId);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Establishment)
                .WithMany(e => e.Services)
                .HasForeignKey(s => s.EstablishmentId);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.TypeService)
                .WithMany(ts => ts.Services)
                .HasForeignKey(s => s.TypeServiceId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClientId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Service)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.ServiceId);

            modelBuilder.Entity<Time>()
                .HasOne(t => t.Service)
                .WithMany(s => s.Times)
                .HasForeignKey(t => t.ServiceId);
        }
    }

}
