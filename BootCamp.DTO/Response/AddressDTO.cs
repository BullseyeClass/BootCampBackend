using BootCamp.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace BootCamp.DTO.Response
{
    public class AddressDTO
    {
        public string PostalCode { get; set; } = string.Empty;
        public string MainAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        [JsonIgnore]
        public string TraineeId { get; set; } = string.Empty;
    }
}
