using CustomerAPI.Models;

namespace CustomerAPI.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private static List<Customer> listCustomer = new List<Customer>
        {
            new Customer
            {
                customerId =1,
                customerName = "Alexander",
                customerAddress = "Jakarta",
                customerPhoneNumber = "1234567890"
            },
            new Customer
            {
                customerId =2,
                customerName = "Rudy",
                customerAddress = "Tangerang",
                customerPhoneNumber = "1234567892"
            },
            new Customer
            {
                customerId =3,
                customerName = "Said",
                customerAddress = "Bekasi",
                customerPhoneNumber = "0999999999"
            },
            new Customer
            {
                customerId =4,
                customerName = "Lee Ping",
                customerAddress = "Butong Brunie",
                customerPhoneNumber = "0888888"
            }

        };

        public async Task<List<Customer>> getAllCustomer()
        {
            return listCustomer;
        }

        public async Task<Customer> getCustomerById(int customerId)
        {
            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null) { return null; }
             return customer;
        }
        public async Task<List<Customer>> deleteCustomerById(int customerId)
         {
            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null) { return null; }
             listCustomer.Remove(customer);
            return listCustomer;
        }

        public async Task<List<Customer>> addCustomer(Customer addCustomer)
        {
            listCustomer.Add(addCustomer);
            return listCustomer;
        }

         public async Task<List<Customer>> updateCustomerById(int customerId, Customer requestUpdate)
         {

            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null)
            {
                return null;
            }

            customer.customerName = requestUpdate.customerName;
            customer.customerAddress = requestUpdate.customerAddress;
            customer.customerPhoneNumber = requestUpdate.customerPhoneNumber;
            return listCustomer;
        }
        
    }
}
