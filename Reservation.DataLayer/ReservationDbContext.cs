using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reservation.DataLayer.Entities;
using System.Reflection;

namespace Reservation.DataLayer
{
    public class ReservationDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public ReservationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<CustomerReservation> CustomerReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
