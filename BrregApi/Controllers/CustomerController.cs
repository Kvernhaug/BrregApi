using System.Threading.Tasks;
using BrregApi.Context;
using BrregApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BrregApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(CustomerDbContext context) : ControllerBase
    {
        private readonly CustomerDbContext _context = context;

        //static private List<Customer> customers = new List<Customer>
        //{
        //    new Customer
        //    {
        //        Id = 1,
        //        Company = new Company
        //        {
        //            Id = 1,
        //            Name = "Bedrift 1",
        //            OrgNumber = "123456789"
        //        }
        //    },
        //    new Customer
        //    {
        //        Id = 2,
        //        Company = new Company
        //        {
        //            Id = 2,
        //            Name = "Bedrift 2",
        //            OrgNumber = "223456789"
        //        }
        //    },
        //};

        [HttpGet("all", Name = "GetAllCustomers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Customer>> AddCustomer(Customer newCustomer)
        {
            if (newCustomer is null)
            {
                return BadRequest("Customer cannot be null.");
            }
            if (newCustomer.Company is null)
            {
                return BadRequest("Customer must have a valid Company object.");
            }
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
        }

        [HttpPut("/update/{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(int id, Customer updatedCustomer)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            customer.UpdateCustomer(updatedCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<Customer>>> GetMatchingCustomers(
                [FromQuery] string? note,
                [FromQuery] string? companyName,
                [FromQuery] string? street,
                [FromQuery] string? postalCode,
                [FromQuery] string? region,
                [FromQuery] string? municipality,
                [FromQuery] string? municipalityNumber,
                [FromQuery] string? organizationType
            )
        {
            if (!string.IsNullOrWhiteSpace(note))
            {
                var results = await context.Customers
                    .Where(c => c.Note != null && c.Note.Contains(note))
                    .ToListAsync();
            }
            

            return Ok();
        }

    }
}
