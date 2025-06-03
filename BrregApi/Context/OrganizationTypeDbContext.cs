using BrregApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrregApi.Context
{
    public class OrganizationTypeDbContext(DbContextOptions<OrganizationTypeDbContext> options) : DbContext(options)
    {
        public DbSet<OrganizationType> Customers => Set<OrganizationType>();
    }
}
