using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracteceService.Models.Sale
{
    public class SaleModel : BaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("billing_date")]
        public DateTime BillingDate { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("customer")]
        public Models.Customer.CustomerModel Customer { get; set; }

        [JsonProperty("product")]
        public Models.Product.ProductModel Product { get; set; }
    }
}
