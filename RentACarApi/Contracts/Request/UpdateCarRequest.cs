using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarApi.Contracts.Request
{
    public class UpdateCarRequest
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string plate { get; set; }
    }
}