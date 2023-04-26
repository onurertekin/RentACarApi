using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarApi.Database.Entities
{
    [Table("Customers", Schema = "dbo")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCIdentityNumber { get; set; }
    }
}