﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.DTO.Response
{
    public class LoginResponseDTO
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
