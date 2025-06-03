namespace BrregApi.Models
{
    public class Company
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string OrgNumber { get; set; }

        public string? Homepage { get; set; }

        public string? Email { get; set; }

        public string? Note { get; set; }

        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public int? OrganizationTypeId { get; set; }
        public OrganizationType? OrganizationType { get; set; }
    }
}
