using BrregApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BrregApi.Context
{
    public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<OrganizationType> OrganizationTypes => Set<OrganizationType>();

        public IQueryable<Customer> GetAllCustomers()
        {
            return Customers
                .Include(c => c.Company)
                    .ThenInclude(co => co.Address)
                .Include(c => c.Company)
                    .ThenInclude(co => co.OrganizationType);
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await GetAllCustomers()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Manually add data to db for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Country = "Norge",
                    CountryCode = "NO",
                    PostalCode = "5007",
                    Region = "BERGEN",
                    Street = ["Parkveien 1"],
                    Municipality = "BERGEN",
                    MunicipalityNumber = "4601"
                },
                new Address
                {
                    Id = 2,
                    Country = "Norge",
                    CountryCode = "NO",
                    PostalCode = "5160",
                    Region = "LAKSEVÅG",
                    Street = ["Damsgårdsveien 175"],
                    Municipality = "BERGEN",
                    MunicipalityNumber = "4601"
                },
                new Address
                {
                    Id = 3,
                    Country = "Norge",
                    CountryCode = "NO",
                    PostalCode = "5536",
                    Region = "HAUGESUND",
                    Street = ["Deco-bygget", "Longhammarvegen 28"],
                    Municipality = "HAUGESUND",
                    MunicipalityNumber = "1106"
                }
            );

            modelBuilder.Entity<OrganizationType>().HasData(
                new OrganizationType
                {
                    Id = 1,
                    Code = "FLI",
                    Description = "Forening/lag/innretning"
                },
                new OrganizationType
                {
                    Id = 2,
                    Code = "FLI",
                    Description = "Forening/lag/innretning"
                },
                new OrganizationType
                {
                    Id = 3,
                    Code = "FLI",
                    Description = "Forening/lag/innretning"
                },
                new OrganizationType
                {
                    Id = 4,
                    Code = "AS",
                    Description = "Aksjeselskap"
                }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "BSI - SEILING",
                    OrgNumber = "916598408",
                    Homepage = "www.bsiseiling.no",
                    Email = "seiling@bsi.no",
                    AddressId = 1,
                    OrganizationTypeId = 1
                },
                new Company
                {
                    Id = 2,
                    Name = "BSI - BADMINTON",
                    OrgNumber = "998008166",
                    Homepage = "badminton.bsi.no/no/",
                    Email = "badminton@bsi.no",
                    OrganizationTypeId = 2
                },
                new Company
                {
                    Id = 3,
                    Name = "BSI - INNEBANDY",
                    OrgNumber = "918995897",
                    Homepage = "www.innebandy.bsi.no",
                    Email = "innebandy@bsi.no",
                    AddressId = 2,
                    OrganizationTypeId = 3
                },
                new Company
                {
                    Id = 4,
                    Name = "APPEX AS",
                    OrgNumber = "995412020",
                    Homepage = "www.appex.no",
                    Email = "hello@appex.no",
                    AddressId = 3,
                    OrganizationTypeId = 4
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Note = "Test",
                    CompanyId = 1
                },
                new Customer
                {
                    Id = 2,
                    Note = "Testing",
                    CompanyId = 2
                },
                new Customer
                {
                    Id = 3,
                    Note = "This is a test",
                    CompanyId = 3
                },
                new Customer
                {
                    Id = 4,
                    Note = null,
                    CompanyId = 4
                }
            );
        }
    }
}
