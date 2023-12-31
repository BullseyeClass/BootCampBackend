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
    public interface ITraineeService
    {
        Task<GenericResponse<TraineeRegistrationResponseDTO>> RegistrationAsync(TraineeRegistrationDTO traineeRegistrationDTO);
       
        Task<GenericResponse<string>> UpdateTraineeAsync(string traineeId, TraineeUpdateDTO traineeUpdateDTO);

        Task<GenericResponse<string>> UpdatePhoneNumberAsync(string phonenumberId, PhoneNumberDTO newPhoneNumber);

        Task<GenericResponse<string>> AddPhoneNumberAsync(PhoneNumberDTO phoneNumberDTO);

        Task<GenericResponse<string>> AddAddressAsync(AddressDTO addressDto);

        Task<GenericResponse<List<AddressDTO>>> GetAddressAsync(string id);
    }
}
