using BootCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BootCamp.DTO.Response
{
    public class PhoneNumberDTO
    {
        public string Extension { get; set; }
        public string Number { get; set; }

        [JsonIgnore]
        public string? TraineeId { get; set; }
    }
}
