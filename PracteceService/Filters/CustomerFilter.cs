using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Filters
{
    public class CustomerFilter : BaseFilter
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }

        [FromQuery(Name = "last_name")]
        public string LastName { get; set; }

        [FromQuery(Name = "email")]
        public string Email { get; set; }

        [FromQuery(Name = "customer_id")]
        public string CustomerId { get; set; }

        [FromQuery(Name = "document_number")]
        public string DocumentNumber { get; set; }
    }
}
