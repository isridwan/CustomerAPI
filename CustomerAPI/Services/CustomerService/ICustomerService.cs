using CustomerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> getAllCustomer();
        Task<Customer> getCustomerById(int customerId);
        Task<List<Customer>> addCustomer(Customer addCustomer);
        Task<List<Customer>> updateCustomerById(int customerId, Customer requestUpdate);
        Task<List<Customer>> deleteCustomerById(int customerId);
       
    }
}
