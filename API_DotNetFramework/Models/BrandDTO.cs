using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DotNetFramework.Models
{
    public class BrandDTO
    {
        [JsonProperty("brand id")]
        public int Id { get; set; }
        [JsonProperty("brand name")]
        public string Name { get; set; }
    }
}