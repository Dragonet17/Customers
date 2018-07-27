using System.Threading.Tasks;
using Customers.Infrastructure.Domains;

namespace Customers.Infrastructure.Repositories.Interfaces {
    public interface IAddressRepository {
        Task DeleteAsync (CustomerAddress customerAddress);
    }
}