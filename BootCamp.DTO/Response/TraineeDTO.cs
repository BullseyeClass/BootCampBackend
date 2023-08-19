using BootCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.DTO.Response
{
    public class TraineeDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public List<PhoneNumberDTO>? PhoneNumbers { get; set; } = new List<PhoneNumberDTO>();
        public List<AddressDTO>? Address { get; set; } = new List<AddressDTO>();
        public List<TestScoreResponseDTO> Tests { get; set; } = new List<TestScoreResponseDTO>();
    }
}
