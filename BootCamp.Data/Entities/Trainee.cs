using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Entities
{
    public class Trainee : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public virtual List<PhoneNumber>? PhoneNumbers { get; set; } = new List<PhoneNumber>();
        public virtual List<Address>? Address { get; set; } = new List<Address>();
    }
}
