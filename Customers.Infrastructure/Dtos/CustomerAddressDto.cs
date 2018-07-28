namespace Customers.Infrastructure.Dtos {
    public class CustomerAddressDto {
        public string FlatNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}