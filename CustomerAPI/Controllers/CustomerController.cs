using CustomerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> listCustomer = new List<Customer>
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
            }

        };

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> getAllCustomer()
        {
            return Ok(listCustomer);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<List<Customer>>> getCustomerById(int customerId)
        {
            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null)
                return NotFound("Sorry the customer doesn't exist");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> addCustomer(Customer addCustomer)
        {
            listCustomer.Add(addCustomer);
            return Ok(listCustomer);

        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult<List<Customer>>> updateCustomerById(int customerId, Customer requestUpdate)
        {
            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null)
                return NotFound("Sorry the customer doesn't exist");
            customer.customerName = requestUpdate.customerName;
            customer.customerAddress = requestUpdate.customerAddress;
            customer.customerPhoneNumber = requestUpdate.customerPhoneNumber;
            return Ok(listCustomer);

        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult<List<Customer>>> deleteCustomerById(int customerId)
        {
            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null)
                return NotFound("Sorry the customer doesn't exist");

            listCustomer.Remove(customer);
            return Ok(listCustomer);

        }

    }
}
