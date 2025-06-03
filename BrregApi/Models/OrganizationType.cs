namespace BrregApi.Models
{
    public class OrganizationType
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public required Company Company { get; set; }
    }
}
