using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarApi.Database.Entities
{
    [Table("RentalTransactions", Schema = "dbo")]
    public class RentalTransaction
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public double Price { get; set; }
    }
}