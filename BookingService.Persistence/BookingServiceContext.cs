using BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookingService.Persistence
{
    public class BookingServiceContext : DbContext
    {
        public BookingServiceContext(DbContextOptions<BookingServiceContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyEmployee> CompanyEmployee { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Service> Service { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfigurationsFromAssembly
                (typeof(BookingServiceContext).Assembly);
        }
    }
}
