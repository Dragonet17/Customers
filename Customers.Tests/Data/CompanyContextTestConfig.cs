using System;
using Customers.Infrastructure.Data;
using Customers.Infrastructure.Domains;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Customers.Tests.Data {
    public class CompanyContextTestConfig : IDisposable {
        public CompanyContext CompanyContext { get; set; }
        public Mock<CompanyContext> CompanyContextMock { get; set; }
        public Mock<DbSet<Customer>> CustomersDbSetMock { get; set; }

        public CompanyContextTestConfig () {
            CompanyContext = GetCompanyEventContext ();
            CompanyContextMock = new Mock<CompanyContext> (GetCompanyEventContext ());
            CustomersDbSetMock = new Mock<DbSet<Customer>> ();
        }

        private DbContextOptions<CompanyContext> GetComapnyContextOptions () {
            var builder = new DbContextOptionsBuilder<CompanyContext> ();
            builder.UseInMemoryDatabase (
                databaseName: "ComanyDb");
            return builder.Options;
        }

        private CompanyContext GetCompanyEventContext () {
            var builderOptions = GetComapnyContextOptions ();
            return new CompanyContext (builderOptions);
        }

        public void Dispose () {
            CompanyContext?.Dispose ();
        }
    }
}