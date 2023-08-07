using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Entities
{
    public class PhoneNumber
    {
        public Guid Id { get; set; }
        public string Extension { get; set; }
        public string Number { get; set; }
        public string UserId { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
