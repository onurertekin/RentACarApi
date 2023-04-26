using RentACarApi.Database;
using RentACarApi.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RentACarApi.Repositories
{
    public class CarRepository : BaseRepository
    {
        public CarRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public List<Car> Search()
        {
            return databaseContext.Cars.ToList();
        }

        public Car GetSingle(int id)
        {
            return databaseContext.Cars.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Create(Car car)
        {
            databaseContext.Cars.Add(car);

            databaseContext.SaveChanges();
        }

        public void Update()
        {
            databaseContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            databaseContext.Remove(car);

            databaseContext.SaveChanges();
        }
    }
}
