using Microsoft.EntityFrameworkCore;
using RentACarApi.Database.Entities;

namespace RentACarApi.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RentalTransaction> RentalTransactions { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}