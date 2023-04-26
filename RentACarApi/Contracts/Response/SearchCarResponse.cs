using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACarApi.Contracts.Response
{
    public class SearchCarResponse
    {
        public class Car
        {
            public long Id { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Year { get; set; }
            public string Plate { get; set; }
        }

        public List<Car> cars { get; set; }

        public void Fill(List<Database.Entities.Car> cars)
        {
            this.cars = cars.Select(x => new Car()
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                Year = x.Year,
                Plate = x.Plate
            }).ToList();
        }
    }
}
