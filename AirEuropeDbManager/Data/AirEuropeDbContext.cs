using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirEuropeDbManager.Data
{
    public class AirEuropeDbContext : DbContext
    {
        public AirEuropeDbContext() : base() { }

        public AirEuropeDbContext(DbContextOptions<AirEuropeDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "AirEuropeDb";
            builder.TrustServerCertificate = true;
            builder.IntegratedSecurity = true;
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AirRoute>().HasOne(a => a.ArrivalAirport).WithMany(a => a.ArrivalAirports).HasForeignKey(a => a.ArrivalAirportId);
            modelBuilder.Entity<AirRoute>().HasOne(a => a.DepartureAirport).WithMany(a => a.DepartureAirports).HasForeignKey(a => a.DepartureAirportId);

            modelBuilder.Entity<ReservedSeat>().HasKey(r => new { r.SeatId, r.ReservationId });

            foreach(var fKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                fKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<ReservedSeat> ReservedSeats { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<AirRoute> AirRoutes { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}
