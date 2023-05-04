using CustomerAPI.Models;
using CustomerAPI.Services.CustomerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> getAllCustomer()
        {
            return await _customerService.getAllCustomer();
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> getCustomerById(int customerId)
        {
            var customer = await _customerService.getCustomerById(customerId);
            if (customer is null)
                return NotFound("Sorry the customer doesn't exist");
            return Ok(customer);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> addCustomer(Customer addCustomer)
        {
            var customer = await _customerService.addCustomer(addCustomer);
            return Ok(customer);
        }
        
        [HttpPut("{customerId}")]
        public async Task<ActionResult<List<Customer>>> updateCustomerById(int customerId, Customer requestUpdate)
        {
            var customer = await _customerService.updateCustomerById(customerId, requestUpdate);    
            if (customer is null)
                return NotFound("Sorry the customer doesn't exist");
            return Ok(customer);

        }
        
        [HttpDelete("{customerId}")]
        public async Task<ActionResult<List<Customer>>> deleteCustomerById(int customerId)
        {
            var customer = await _customerService.deleteCustomerById(customerId);
            if (customer is null)
                return NotFound("Sorry the customer doesn't exist");
            return Ok(customer);

        }
        

    }
}
