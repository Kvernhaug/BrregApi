using BrregApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrregApi.Context
{
    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();
    }
}
