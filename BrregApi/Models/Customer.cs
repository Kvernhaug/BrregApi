namespace BrregApi.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string? Note {  get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            if (updatedCustomer.Note != null)
                Note = updatedCustomer.Note;

            if(updatedCustomer.Company != null)
            {
                if (Company == null)
                    Company = updatedCustomer.Company;
                else
                    Company.UpdateCompany(updatedCustomer.Company);
            }
        }
    }   
}
