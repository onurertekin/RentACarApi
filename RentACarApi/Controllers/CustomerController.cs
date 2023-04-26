using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarApi.Contracts.Request;
using RentACarApi.Contracts.Response;
using RentACarApi.Repositories;

namespace RentACarApi.Controllers
{
    [ApiController]
    [Route("/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// Search Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SearchCustomerResponse> Search()
        {
            var customers = customerRepository.Search();

            SearchCustomerResponse response = new SearchCustomerResponse();
            response.Fill(customers);

            return new JsonResult(response);
        }

        [HttpGet]
        [Route("{customerId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GetSingleCustomerResponse> GetSingle(int customerId)
        {
            var customer = customerRepository.GetSingle(customerId);

            if (customer == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return null;
            }

            GetSingleCustomerResponse response = new GetSingleCustomerResponse();
            response.Fill(customer);

            return new JsonResult(response);
        }

        //[HttpPost]
        //[Route("")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public void Create(CreateCustomerRequest request)
        //{
        //    Database.Entities.Customer customer = new Database.Entities.Customer();
        //    customer.Brand = request.brand;
        //    customer.Model = request.model;
        //    customer.Year = request.year;
        //    customer.Plate = request.plate;

        //    customerRepository.Create(customer);
        //}

        //[HttpPut]
        //[Route("{customerId}")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public void Update(int customerId, UpdateCustomerRequest request)
        //{
        //    var customer = customerRepository.GetSingle(customerId);

        //    if (customer == null)
        //    {
        //        HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        //        return;
        //    }

        //    customer.Brand = request.brand;
        //    customer.Model = request.model;
        //    customer.Year = request.year;
        //    customer.Plate = request.plate;

        //    customerRepository.Update();
        //}

        [HttpDelete]
        [Route("{customerId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void Delete(int customerId)
        {
            var customer = customerRepository.GetSingle(customerId);

            if (customer == null)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            customerRepository.Delete(customer);
        }
    }
}