namespace Customer.Infrastructure.Domains {
    public class Customer {
        public string Name { get; set; }

        public Customer () {

        }
        public Customer (string name) {
            Name = name;
        }
    }
}