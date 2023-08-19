using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BootCamp.BusinessLogic.Services.Implementations;
using BootCamp.DTO.Response;
using BootCamp.DTO;
using System;
using System.Threading.Tasks;
using BootCamp.BusinessLogic.Services.Interfaces;

namespace BootCamp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetUserByIdController : ControllerBase
    {

        private readonly IGetUserByIdService _getUserByIdService;
        private readonly ILogger<GetUserByIdController> _logger;

        public GetUserByIdController(IGetUserByIdService getUserByIdService, ILogger<GetUserByIdController> logger)
        {
            _getUserByIdService = getUserByIdService;
            _logger = logger;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(GenericResponse<TestScoreResponseDTO>), 200)]
        public async Task<IActionResult> GetUserById(string userId)
        {
            try
            {
                var user = await _getUserByIdService.GetUserByIdAsync(userId);

                if (user == null)
                {
                    return NotFound(); // Return HTTP 404 Not Found
                }

                //var response = new GenericResponse<TestScoreResponseDTO>
                //{
                //    Data = user,
                //    Success = true,
                //    Message = "User data retrieved successfully."
                //};

                return Ok(user); // Return HTTP 200 OK
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the user.");
                return StatusCode(500, "An error occurred while processing your request."); // Return HTTP 500 Internal Server Error
            }
        }
    }
}
