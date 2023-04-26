using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarApi.Database.Entities
{
    [Table("Cars", Schema = "dbo")]
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Plate { get; set; }
    }
}