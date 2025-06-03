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
    }
}
