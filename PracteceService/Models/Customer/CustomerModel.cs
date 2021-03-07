using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Models.Customer
{
    public class CustomerModel : BaseModel
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("document_number")]
        public string DocumentNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone_numebr")]
        public string PhoneNumebr { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("birth_date")]
        public DateTime? BirthDate { get; set; }
    }
}
