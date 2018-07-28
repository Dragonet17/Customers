namespace Customers.Infrastructure.Dtos {
    public class CustomerWithAddressDto {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public CustomerAddressDto CustomerAddress { get; set; }
    }
}