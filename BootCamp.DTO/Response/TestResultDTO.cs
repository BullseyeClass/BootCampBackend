using BootCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.DTO.Response
{
    public class TestResultDTO
    {
        public string StudentId { get; set; }
        public int Score { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set;}
    }
}
