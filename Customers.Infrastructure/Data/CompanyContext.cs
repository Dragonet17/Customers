using Customers.Infrastructure.Domains;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infrastructure.Data {
    public class CompanyContext : DbContext {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomersAddresses { get; set; }
        public CompanyContext (DbContextOptions<CompanyContext> options) : base (options) { }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Customer> ()
                .HasOne (a => a.CustomerAddress)
                .WithOne (b => b.Customer)
                .HasForeignKey<CustomerAddress> (b => b.CustomerId)
                .OnDelete (DeleteBehavior.Cascade);
        }

    }
}