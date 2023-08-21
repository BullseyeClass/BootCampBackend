using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.DTO.Request
{
    public class TraineeUpdateDTO
    {
        public string FirstName { get; set; } = string.Empty;   
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
    }
}
