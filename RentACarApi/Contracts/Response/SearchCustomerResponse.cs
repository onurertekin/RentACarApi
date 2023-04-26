using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACarApi.Contracts.Response
{
    public class SearchCustomerResponse
    {
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string TCIdentityNumber { get; set; }
        }

        public List<Customer> customers { get; set; }

        public void Fill(List<Database.Entities.Customer> customers)
        {
            this.customers = customers.Select(x => new Customer()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                TCIdentityNumber = x.TCIdentityNumber
            }).ToList();

            //Bu da yukardaki ile ayný yöntem
            //foreach (var customer in customers)
            //{
            //    this.customers.Add(new Customer()
            //    {
            //        Id = customer.Id,
            //        Name = customer.Name,
            //        Surname = customer.Surname,
            //        TCIdentityNumber = customer.TCIdentityNumber
            //    });
            //}
        }
    }
}