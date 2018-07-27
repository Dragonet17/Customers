using System;

namespace Customers.Infrastructure.Domains {
    public class CustomerAddress {

        public int Id { get; set; }
        public string FlatNumber { get; private set; }
        public string BuildingNumber { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        public CustomerAddress () { }
        public CustomerAddress (string flatNumber, string buildingNumber, string street, string city, string zipCode) {
            SetFlatNumber (flatNumber);
            SetBuildingNumber (buildingNumber);
            SetStreet (street);
            SetCity (city);
            SetZipCode (zipCode);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        #region privateMethods

        private void SetFlatNumber (string flatNumber) {
            if (string.IsNullOrEmpty (flatNumber))
                throw new Exception ("The name can not be empty");
            FlatNumber = flatNumber;
        }

        private void SetBuildingNumber (string buildingNumber) {
            if (string.IsNullOrEmpty (buildingNumber))
                throw new Exception ("The name can not be empty");
            BuildingNumber = buildingNumber;
        }

        private void SetStreet (string street) {
            if (string.IsNullOrEmpty (street))
                throw new Exception ("The name can not be empty");
            Street = street;
        }

        private void SetCity (string city) {
            if (string.IsNullOrEmpty (city))
                throw new Exception ("The name can not be empty");
            City = city;
        }

        private void SetZipCode (string zipCode) {
            if (string.IsNullOrEmpty (zipCode))
                throw new Exception ("The name can not be empty");
            ZipCode = zipCode;
        }

        #endregion

        #region publicMethods

        public void Update (string flatNumber, string buildingNumber, string street, string city, string zipCode) {
            SetFlatNumber (flatNumber);
            SetBuildingNumber (buildingNumber);
            SetStreet (street);
            SetCity (city);
            SetZipCode (zipCode);
            UpdatedAt = DateTime.UtcNow;
        }

        #endregion
    }
}