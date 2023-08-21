using BootCamp.BusinessLogic.Services.Interfaces;
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

        [HttpPost("{id}/add-address")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> AddAddress(string id, [FromBody] AddressDTO addressDto)
        {
            var response = await _traineeService.AddAddressAsync(id, addressDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


        [HttpGet("{id}/get-address")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> GetAddresses(string id)
        {
            var response = await _traineeService.GetAddressAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpPut("updatePhoneNumber/{phonenumberId}")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> UpdatePhoneNumberAsync(string phonenumberId, [FromBody] PhoneNumberDTO newPhoneNumber)
        {
            // Validate phonenumberId and newPhoneNumber
            if (string.IsNullOrEmpty(phonenumberId) || newPhoneNumber == null)
            {
                return BadRequest("Invalid input data.");
            }

            var response = await _traineeService.UpdatePhoneNumberAsync(phonenumberId, newPhoneNumber);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }




        [HttpPost("{id}/add PhoneNumber")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> AddPhoneNumber(string id, [FromBody] PhoneNumberDTO phoneNumberDTO)
        {
            var response = await _traineeService.AddPhoneNumberAsync(id, phoneNumberDTO);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


        [HttpPut("updateTrainee/{traineeId}")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> UpdateTraineeAsync(string traineeId, [FromBody] TraineeUpdateDTO traineeUpdateDTO)
        {

            if (string.IsNullOrEmpty(traineeId) || traineeUpdateDTO == null)
            {
                return BadRequest("Invalid input data.");
            }

            var result = await _traineeService.UpdateTraineeAsync(traineeId, traineeUpdateDTO);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



    }
    
}

