using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProductImport.Model
{
    public class CapterraModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "twitter")]
        public string Twitter { get; set; }
    }
}
