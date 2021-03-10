using GroceryStoreAPI.Abstract;
using GroceryStoreAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GroceryStoreAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICollection<Customer> _customer;

        //we don't have real database so I created dummy data in this fake implementation of ICustomerService interface, which we are going to inject to our controller at the time of testing.
        public CustomerService()
        {
            _customer = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Bob"},
                new Customer() {Id = 2, Name = "Mary"},
                new Customer() {Id = 3, Name = "Joe"}
            };
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customer;
        }

        
        public Customer GetCustomerById(int customerId)
        {
            return _customer.Where(x => x.Id == customerId).FirstOrDefault();
        }


        public Customer AddCustomer(Customer customer)
        {
            customer.Id = _customer.Last().Id + 1;
            _customer.Add(customer);
            return customer;

        }
        
        public Customer UpdateCustomerById(Customer customer)
        {
            var existing = _customer.FirstOrDefault(a => a.Id == customer.Id);
            if (existing != null)
            {
                _customer.First(a => a.Id == customer.Id).Name = customer.Name;
                return customer;
            }
            return existing;
        }
    }
}
