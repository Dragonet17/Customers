using System.Threading.Tasks;
using Customers.Infrastructure.Services.Interfaces;

namespace Customers.Infrastructure.Services {
    public class CustomerService : ICustomerService {
        public Task CreateAsync (string name, string surname, string phoneNumber, string flatNumber, string buildingNumber, string street, string city, string zipCode) {
            throw new System.NotImplementedException ();
        }

        public Task DeleteAsync (int customerId) {
            throw new System.NotImplementedException ();
        }

        public Task<bool> ExistByPhoneNumberAsync (string phoneNumber) {
            throw new System.NotImplementedException ();
        }

        public Task UpdateAsync (string name, string surname, string phoneNumber, string flatNumber, string buildingNumber, string street, string city, string zipCode) {
            throw new System.NotImplementedException ();
        }
    }
}