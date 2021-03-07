using Newtonsoft.Json;
using PracteceService.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracteceService.Models
{
    public class BaseModel
    {
        [System.Text.Json.Serialization.JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("update_date")]
        public DateTime? UpdateDate { get; set; }

        [JsonProperty("is_active", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsActive { get; set; }
    }
}
