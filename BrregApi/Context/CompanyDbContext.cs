using BrregApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrregApi.Context
{
    public class CompanyDbContext(DbContextOptions<CompanyDbContext> options) : DbContext(options)
    {
        public DbSet<Company> Customers => Set<Company>();
    }
}
