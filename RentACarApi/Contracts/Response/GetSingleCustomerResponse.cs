namespace RentACarApi.Contracts.Response
{
    public class GetSingleCustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCIdentityNumber { get; set; }

        public void Fill(Database.Entities.Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Surname = customer.Surname;
            TCIdentityNumber = customer.TCIdentityNumber;
        }
    }
}
