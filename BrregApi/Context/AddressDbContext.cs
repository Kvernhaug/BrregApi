using BrregApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrregApi.Context
{
    public class AddressDbContext(DbContextOptions<AddressDbContext> options) : DbContext(options)
    {
        public DbSet<Address> Customers => Set<Address>();
    }
}
