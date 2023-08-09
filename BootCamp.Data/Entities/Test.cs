using BootCamp.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Entities
{
    public class Test : Common
    {
        public string StudentId { get; set; }
        public int Score { get; set; }
        public string TestType { get; set; }
        public bool IsPassed { get; set; }
        public string TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
