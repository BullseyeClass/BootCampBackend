﻿using BootCamp.DTO.Request;
using BootCamp.DTO.Response;
using BootCamp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.BusinessLogic.Services.Interfaces
{
    public interface IAuthentication
    {
        Task<GenericResponse<LoginResponseDTO>> LoginAsync(LoginRequestDTO userRequest);
    }
}
