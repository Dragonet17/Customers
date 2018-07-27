using System.Threading.Tasks;
using Customers.Infrastructure.Data;
using Customers.Infrastructure.Domains;
using Customers.Infrastructure.Repositories.Interfaces;

namespace Customers.Infrastructure.Repositories {
    public class AddressRepository : IAddressRepository {
        private readonly CompanyContext _context;

        public AddressRepository (CompanyContext context) {
            _context = context;
        }
        public async Task DeleteAsync (CustomerAddress customerAddress) {
            _context.CustomersAddresses.Remove (customerAddress);
            await _context.SaveChangesAsync ();
        }
    }
}