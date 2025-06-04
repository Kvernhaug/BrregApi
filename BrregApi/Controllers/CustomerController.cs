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

        [HttpGet("all", Name = "GetAllCustomers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await _context.GetAllCustomers().ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _context.GetCustomerById(id);
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

            // Ignore any ids provided in request body
            newCustomer.Id = 0;
            newCustomer.Company.Id = 0;
            if (newCustomer.Company.Address is not null)
            {
                newCustomer.Company.Address.Id = 0;
            }
            if (newCustomer.Company.OrganizationType is not null)
            {
                newCustomer.Company.OrganizationType.Id = 0;
            }

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomerAsync(Customer updatedCustomer)
        {
            var customer = await _context.Customers.FindAsync(updatedCustomer.Id);
            if (customer is null)
            {
                return NotFound();
            }
            customer.UpdateCustomer(updatedCustomer);
            await _context.SaveChangesAsync();

            return Ok(updatedCustomer);
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
