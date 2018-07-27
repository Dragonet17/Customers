using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.Infrastructure.Domains;

namespace Customers.Infrastructure.Repositories.Interfaces {
    public interface ICustomerRepository {
        Task AddAsync (Customer customerAddress);
        Task UpdateAsync (Customer customerAddress);
        Task<Customer> GetAsync (int id, bool asNoTracking = false);
        Task<Customer> GetByPhoneNumberAsync (string phoneNumber, bool asNoTracking = false);
        Task<Customer> GetWithAddressAsync (int id, bool asNoTracking = false);
        Task<IEnumerable<Customer>> GetAllWithAddresesAsync ();
        Task DeleteAsync (Customer customerAddress);

    }
}