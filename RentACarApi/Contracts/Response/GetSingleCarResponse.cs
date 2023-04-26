namespace RentACarApi.Contracts.Response
{
    public class GetSingleCarResponse
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Plate { get; set; }

        public void Fill(Database.Entities.Car car)
        {
            Id = car.Id;
            Brand = car.Brand;
            Model = car.Model;
            Year = car.Year;
            Plate = car.Plate;
        }
    }
}
