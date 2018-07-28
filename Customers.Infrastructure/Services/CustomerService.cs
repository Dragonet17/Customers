using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Customers.Infrastructure.Domains;
using Customers.Infrastructure.Dtos;
using Customers.Infrastructure.Repositories.Interfaces;
using Customers.Infrastructure.Services.Interfaces;

namespace Customers.Infrastructure.Services {
    public class CustomerService : ICustomerService {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IMapper _mapper;

        public CustomerService (ICustomerRepository customerRepository,
            ICustomerAddressRepository customerAddressRepository,
            IMapper mapper) {
            _customerRepository = customerRepository;
            _customerAddressRepository = customerAddressRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync (string name, string surname, string phoneNumber, string flatNumber, string buildingNumber, string street, string city, string zipCode) {
            var customer = new Customer (name, surname, phoneNumber);
            customer.AddAddress (new CustomerAddress (flatNumber, buildingNumber, street, city, zipCode));
            await _customerRepository.AddAsync (customer);
        }

        public async Task<CustomerWithAddressDto> GetAsync (int id) {
            var customer = await _customerRepository.GetWithAddressAsync (id);
            if (customer == null || customer.CustomerAddress == null)
                throw new Exception ("Customer with this id does not exists");
            return _mapper.Map<CustomerWithAddressDto> (customer);
        }

        public async Task<IEnumerable<CustomerWithAddressDto>> BrowseAsync (string query = null) {
            var customersWithAddresses = await _customerRepository.GetAllWithAddresesAsync ();
            if (!string.IsNullOrEmpty (query))
                customersWithAddresses = customersWithAddresses.Where (a =>
                    a.Name.ToLowerInvariant ().Contains (query.ToLowerInvariant ()) ||
                    a.Surname.ToLowerInvariant ().Contains (query.ToLowerInvariant ()) ||
                    a.TelephoneNumber.ToLowerInvariant ().Contains (query.ToLowerInvariant ()) ||
                    a.CustomerAddress.Street.ToLowerInvariant ().Contains (query.ToLowerInvariant ()) ||
                    a.CustomerAddress.City.ToLowerInvariant ().Contains (query.ToLowerInvariant ()));
            return _mapper.Map<IEnumerable<CustomerWithAddressDto>> (customersWithAddresses);
        }

        public async Task<bool> ExistByPhoneNumberAsync (string phoneNumber) =>
            await _customerRepository.GetByPhoneNumberAsync (phoneNumber, true) != null;

        public async Task UpdateAsync (int customerId, string name, string surname, string phoneNumber, string flatNumber, string buildingNumber, string street, string city, string zipCode) {
            var customer = await _customerRepository.GetWithAddressAsync (customerId);
            if (customer == null || customer.CustomerAddress == null)
                throw new Exception ("Customer with this id does not exist");
            if (customer.TelephoneNumber != phoneNumber && await ExistByPhoneNumberAsync (phoneNumber))
                throw new Exception ("Phone number is already taken.");
            customer.Update (name, surname, phoneNumber);
            customer.CustomerAddress.Update (flatNumber, buildingNumber, street, city, zipCode);
            await _customerRepository.UpdateAsync (customer);
        }
        public async Task DeleteAsync (int customerId) {
            var customer = await _customerRepository.GetAsync (customerId);
            if (customer == null)
                throw new Exception ("Customer with this id does not exist");
            // await _customerAddressRepository.DeleteAsync (customer.CustomerAddress);
            await _customerRepository.DeleteAsync (customer);
        }
    }
}