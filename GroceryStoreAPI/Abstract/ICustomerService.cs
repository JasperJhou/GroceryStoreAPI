using GroceryStoreAPI.Entities;
using System.Collections.Generic;

namespace GroceryStoreAPI.Abstract
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomerById(Customer customer);
    }
}
