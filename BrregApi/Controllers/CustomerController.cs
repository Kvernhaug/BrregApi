using BrregApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrregApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static private List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Company = new Company
                {
                    Id = 1,
                    Name = "Bedrift 1",
                    OrgNumber = "123456789"
                }
            },
            new Customer
            {
                Id = 2,
                Company = new Company
                {
                    Id = 2,
                    Name = "Bedrift 2",
                    OrgNumber = "223456789"
                }
            },
        };

        [HttpGet(Name = "GetAllCustomers")]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "GetCustomerById")] 
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> AddCustomer(Customer newCustomer)
        {
            if (newCustomer is null)
            {
                return BadRequest();
            }
            newCustomer.Id = customers.Max(c => c.Id) + 1;
            customers.Add(newCustomer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id , Customer updatedCustomer)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            customer.UpdateCustomer(updatedCustomer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            customers.Remove(customer);
            return NoContent();
        }
    }
}
