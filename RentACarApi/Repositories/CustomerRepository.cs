using RentACarApi.Database;
using RentACarApi.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RentACarApi.Repositories
{
    public class CustomerRepository : BaseRepository
    {
        public CustomerRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public List<Customer> Search()
        {
            return databaseContext.Customers.ToList();
        }

        public Customer GetSingle(int id)
        {
            return databaseContext.Customers.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Create(Customer customer)
        {
            databaseContext.Customers.Add(customer);

            databaseContext.SaveChanges();
        }

        public void Update()
        {
            databaseContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            databaseContext.Remove(customer);

            databaseContext.SaveChanges();
        }
    }
}
