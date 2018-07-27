namespace Customers.Infrastructure.Domains {
    public class Customer {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNumber { get; set; }
        public CustomerAddress CustomerAddress { get; set; }

    }
}