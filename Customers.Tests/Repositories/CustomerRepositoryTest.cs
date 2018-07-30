using System.Threading.Tasks;
using Customers.Infrastructure.Domains;
using Customers.Infrastructure.Repositories;
using Customers.Infrastructure.Repositories.Interfaces;
using Customers.Tests.Data;
using FluentAssertions;
using Xunit;

namespace Customers.Tests.Repositories {
    public class CustomerRepositoryTest : IClassFixture<CompanyContextTestConfig> {
        private readonly CompanyContextTestConfig _dbContextConfig;
        public CustomerRepositoryTest (CompanyContextTestConfig dbContextConfig) {
            _dbContextConfig = dbContextConfig;
        }

        [Fact]
        public async Task when_adding_new_customer_it_should_be_added_correctly_to_the_db () {
            ICustomerRepository _customerRepository = new CustomerRepository (_dbContextConfig.CompanyContext);
            var customer = new Customer ("Karol", "Cichon", "+48504400336");
            customer.AddAddress (new CustomerAddress ("27", "28", "Krakowska", "Kraków", "31-416"));
            await _customerRepository.AddAsync (customer);
            var existingCustomer = await _customerRepository.GetByPhoneNumberAsync (customer.TelephoneNumber);
            Assert.Equal (customer, existingCustomer);
        }

        [Fact]
        public async Task when_updated_customer_it_should_be_updated_correctly_in_the_db () {
            ICustomerRepository _customerRepository = new CustomerRepository (_dbContextConfig.CompanyContext);

            var customer1 = new Customer ("Justyna", "Stanczyk", "+48662622117");
            customer1.AddAddress (new CustomerAddress ("190", "108", "Wadowica", "Kraków", "31-416"));
            var customer2 = new Customer ("Karol", "Cichon", "+48504400336");
            customer2.AddAddress (new CustomerAddress ("117", "06", "Krakowska", "Limanowa", "31-416"));
            await _customerRepository.AddAsync (customer1);
            await _customerRepository.AddAsync (customer2);
            var existingCustomer = await _customerRepository.GetByPhoneNumberAsync (customer1.TelephoneNumber);
            var existingCustomerWithAddress = await _customerRepository.GetWithAddressAsync (existingCustomer.Id);
            existingCustomerWithAddress.Update (existingCustomerWithAddress.Name, "Cichon", existingCustomerWithAddress.TelephoneNumber);
            existingCustomerWithAddress.CustomerAddress.Update ("27", "28", "Krakowska", "Kraków", existingCustomerWithAddress.CustomerAddress.ZipCode);
            // // await _customerRepository.UpdateAsync (existingCustomerWithAddress);
            // var updatedCustomerWithAddress = await _customerRepository.GetWithAddressAsync (existingCustomerWithAddress.Id);
            // // Assert.Equal (existingCustomerWithAddress, updatedCustomerWithAddress);
            // Assert.Equal (customer2, existingCustomerWithAddress);
            customer1.ShouldBeEquivalentTo (existingCustomer);
        }

        [Fact]
        public async Task added_customer_should_be_removed_correctly_in_the_db () {
            ICustomerRepository _customerRepository = new CustomerRepository (_dbContextConfig.CompanyContext);

            var customer = new Customer ("Jan", "Kowalski", "+48123456789");
            customer.AddAddress (new CustomerAddress ("1", "2", "Krotka", "Kraków", "31-416"));

            await _customerRepository.AddAsync (customer);
            var existingCustomer = await _customerRepository.GetByPhoneNumberAsync (customer.TelephoneNumber);
            await _customerRepository.DeleteAsync (existingCustomer);
            var removedCustomer = await _customerRepository.GetAsync (existingCustomer.Id);
            Assert.Equal (null, removedCustomer);
        }
    }
}