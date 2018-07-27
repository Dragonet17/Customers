using System.Threading.Tasks;

namespace Customers.Infrastructure.Services.Interfaces {
    public interface ICustomerService {
        Task<bool> ExistByPhoneNumberAsync (string phoneNumber);
        Task CreateAsync (string name, string surname, string phoneNumber,
            string flatNumber, string buildingNumber, string street, string city, string zipCode);

        Task UpdateAsync (int customerId, string name, string surname, string phoneNumber,
            string flatNumber, string buildingNumber, string street, string city, string zipCode);
        Task DeleteAsync (int customerId);
    }
}