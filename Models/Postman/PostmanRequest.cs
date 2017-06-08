using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taoyuan_Traffic.Models.Postman
{
    public class PostmanRequest
    {
        [JsonProperty(PropertyName = "collectionId")]
        public Guid CollectionId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "headers")]
        public string Headers { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "dataMode")]
        public string DataMode { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }
    }
}