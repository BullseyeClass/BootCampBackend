using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.DTO.Request
{
    using System.ComponentModel.DataAnnotations;

    public record TraineeRegistrationDTO
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Phone number is required")]

        public string PhoneNumber { get; set; }
    }

}
