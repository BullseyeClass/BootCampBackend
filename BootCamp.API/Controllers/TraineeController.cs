﻿using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.DTO;
using BootCamp.DTO.Request;
using BootCamp.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly ITraineeService _traineeService;

        public TraineeController(ITraineeService traineeService)
        {
            this._traineeService = traineeService;
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(GenericResponse<TraineeRegistrationResponseDTO>), 200)]

        public async Task<IActionResult> RegisterAsync([FromBody] TraineeRegistrationDTO traineeRegistrationDTO)
        {
            var response = await _traineeService.RegistrationAsync(traineeRegistrationDTO);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
