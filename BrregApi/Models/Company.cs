namespace BrregApi.Models
{
    public class Company
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string OrgNumber { get; set; }

        public string? Homepage { get; set; }

        public string? Email { get; set; }

        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public int? OrganizationTypeId { get; set; }
        public OrganizationType? OrganizationType { get; set; }


        public void UpdateCompany(Company updated)
        {
            if (!string.IsNullOrWhiteSpace(updated.Name))
                Name = updated.Name;

            if (!string.IsNullOrWhiteSpace(updated.OrgNumber))
                OrgNumber = updated.OrgNumber;

            if (updated.Homepage != null)
                Homepage = updated.Homepage;

            if (updated.Email != null)
                Email = updated.Email;

            if (updated.Address != null)
            {
                if (Address == null)
                    Address = updated.Address;
                else
                    Address.UpdateAddress(updated.Address);
            }

            if (updated.OrganizationType != null)
            {
                if (OrganizationType == null)
                    OrganizationType = updated.OrganizationType;
                else
                    OrganizationType.UpdateOrganizationType(updated.OrganizationType);
            }
        }
    }
}
