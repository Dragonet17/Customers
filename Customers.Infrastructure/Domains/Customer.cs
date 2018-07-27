using System;

namespace Customers.Infrastructure.Domains {
    public class Customer {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string TelephoneNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public CustomerAddress CustomerAddress { get; private set; }

        protected Customer () { }

        public Customer (string name, string surname, string telephoneNumber) {
            SetName (name);
            SetSurname (surname);
            SetTelephoneNumber (telephoneNumber);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        #region privateMethods

        private void SetName (string name) {
            if (string.IsNullOrEmpty (name))
                throw new Exception ("The name can not be empty");
            Name = name;
        }

        private void SetSurname (string surname) {
            if (string.IsNullOrEmpty (surname))
                throw new Exception ("The name can not be empty");
            Surname = surname;
        }

        private void SetTelephoneNumber (string telephoneNumber) {
            if (string.IsNullOrEmpty (telephoneNumber))
                throw new Exception ("The name can not be empty");
            TelephoneNumber = telephoneNumber;
        }

        #endregion

        #region publicMethods

        public void Update (string name, string surname, string telephoneNumber) {
            SetName (name);
            SetSurname (surname);
            SetTelephoneNumber (telephoneNumber);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddAddress (CustomerAddress customerAddress) {
            if (customerAddress == null)
                throw new Exception ("Customer address can not be null");
            CustomerAddress = customerAddress;
        }

        #endregion

    }
}