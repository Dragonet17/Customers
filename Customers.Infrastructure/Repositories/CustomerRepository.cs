using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.Infrastructure.Data;
using Customers.Infrastructure.Domains;
using Customers.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infrastructure.Repositories {
    public class CustomerRepository : ICustomerRepository {
        private readonly CompanyContext _context;

        public CustomerRepository (CompanyContext context) {
            _context = context;
        }

        public async Task AddAsync (Customer customer) {
            await _context.AddAsync (customer);
            await _context.SaveChangesAsync ();
        }

        public async Task<IEnumerable<Customer>> GetAllWithAddresesAsync () =>
            await Task.FromResult (_context.Customers.Include (a => a.CustomerAddress).AsNoTracking ().AsEnumerable ());

        public async Task<Customer> GetAsync (int id, bool asNoTracking = false) {
            if (asNoTracking)
                return await _context.Customers.AsNoTracking ().SingleOrDefaultAsync (a => a.Id == id);
            return await _context.Customers.SingleOrDefaultAsync (a => a.Id == id);
        }

        public async Task<Customer> GetByPhoneNumberAsync (string phoneNumber, bool asNoTracking = false) {
            if (asNoTracking)
                return await _context.Customers.AsNoTracking ().SingleOrDefaultAsync (a => a.TelephoneNumber == phoneNumber);
            return await _context.Customers.SingleOrDefaultAsync (a => a.TelephoneNumber == phoneNumber);
        }

        public async Task<Customer> GetWithAddressAsync (int id, bool asNoTracking = false) {
            if (asNoTracking)
                return await _context.Customers.Include (a => a.CustomerAddress).AsNoTracking ().SingleOrDefaultAsync (a => a.Id == id);
            return await _context.Customers.Include (a => a.CustomerAddress).SingleOrDefaultAsync (a => a.Id == id);
        }

        public async Task UpdateAsync (Customer customer) {
            _context.Customers.Update (customer);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteAsync (Customer customer) {
            _context.Customers.Remove (customer);
            await _context.SaveChangesAsync ();
        }
    }
}