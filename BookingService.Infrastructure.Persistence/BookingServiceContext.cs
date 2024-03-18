using BookingService.Application.Contracts.Presentation;
using BookingService.Domain.Entities;
using BookingService.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BookingService.Infrastructure.Persistence
{
    public class BookingServiceContext : DbContext
    {
        private readonly ICurrentUserService currentUserService;

        public BookingServiceContext(DbContextOptions<BookingServiceContext> options, ICurrentUserService currentUserService) : base(options)
        {
            this.currentUserService = currentUserService;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Calendar> Calendar { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfigurationsFromAssembly
                (typeof(BookingServiceContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = currentUserService.UserId?.ToString() ?? "";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = currentUserService.UserId?.ToString() ?? "";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
