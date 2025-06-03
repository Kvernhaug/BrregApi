namespace BrregApi.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string? Country { get; set; }

        public string? CountryCode { get; set; }

        public string? PostalCode { get; set; }

        public string? Region { get; set; }

        public string[]? Street { get; set; }

        public string? Municipality { get; set; }

        public string? MunicipalityNumber { get; set; }

        public required Company Company { get; set; }


        public void UpdateAddress(Address updatedAddress)
        {
            if (updatedAddress.Country != null)
                Country = updatedAddress.Country;

            if (updatedAddress.CountryCode != null)
                CountryCode = updatedAddress.CountryCode;

            if (updatedAddress.PostalCode != null)
                PostalCode = updatedAddress.PostalCode;

            if (updatedAddress.Region != null)
                Region = updatedAddress.Region;

            if (updatedAddress.Street != null)
                Street = updatedAddress.Street;

            if (updatedAddress.Municipality != null)
                Municipality = updatedAddress.Municipality;

            if (updatedAddress.MunicipalityNumber != null)
                MunicipalityNumber = updatedAddress.MunicipalityNumber;
        }
    }
}
