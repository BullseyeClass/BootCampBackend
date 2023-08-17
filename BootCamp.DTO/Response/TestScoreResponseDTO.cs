using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.DTO.Response
{
    public class TestScoreResponseDTO
    {
        public string Id { get; set; } 
        public string TestType { get; set; }
        public int Score { get; set; }
        public bool IsPassed { get; set; }

    }
}
