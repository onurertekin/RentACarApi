using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarApi.Contracts.Request;
using RentACarApi.Contracts.Response;
using RentACarApi.Repositories;

namespace RentACarApi.Controllers
{
    [ApiController]
    [Route("/cars")]
    public class CarController : ControllerBase
    {
        private readonly CarRepository carRepository;

        public CarController(CarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        /// <summary>
        /// Search Car
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SearchCarResponse> Search()
        {
            var cars = carRepository.Search();

            SearchCarResponse response = new SearchCarResponse();
            response.Fill(cars);

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("{carId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GetSingleCarResponse> GetSingle(int carId)
        {
            var car = carRepository.GetSingle(carId);

            if (car == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }

            GetSingleCarResponse response = new GetSingleCarResponse();
            response.Fill(car);

            return new JsonResult(response);
        }

        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Create(CreateCarRequest request)
        {
            Database.Entities.Car car = new Database.Entities.Car();
            car.Brand = request.brand;
            car.Model = request.model;
            car.Year = request.year;
            car.Plate = request.plate;

            carRepository.Create(car);
        }

        [HttpPut]
        [Route("{carId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Update(int carId, UpdateCarRequest request)
        {
            var car = carRepository.GetSingle(carId);

            if (car == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            car.Brand = request.brand;
            car.Model = request.model;
            car.Year = request.year;
            car.Plate = request.plate;

            carRepository.Update();
        }

        [HttpDelete]
        [Route("{carId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Delete(int carId)
        {
            var car = carRepository.GetSingle(carId);

            if (car == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            carRepository.Delete(car);
        }
    }
}