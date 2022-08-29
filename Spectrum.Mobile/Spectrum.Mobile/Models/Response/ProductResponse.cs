using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Spectrum.Mobile.Models.Response
{
    public class ProductResponse
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}

