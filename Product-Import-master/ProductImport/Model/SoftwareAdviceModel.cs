using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProductImport.Model
{
    public class SoftwareAdviceModel
    {
        /*Just to test comit and pul request second time*/
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        [JsonPropertyName("twitter")]
        public string Twitter { get; set; }
    }

    public class SoftwareAdviceModelList
    {
        [JsonPropertyName("products")]
        public List<SoftwareAdviceModel> Products { get; set; }
    }
}
