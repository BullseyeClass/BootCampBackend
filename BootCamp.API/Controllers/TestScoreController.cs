using BootCamp.BusinessLogic.Services.Implementations;
using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.DTO.Response;
using BootCamp.DTO;
using Microsoft.AspNetCore.Mvc;
using BootCamp.Data.Entities;

namespace BootCamp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestScoreController : ControllerBase
    {
        private readonly ITestScoresService _testScoresService;

        public TestScoreController(ITestScoresService testScoreService)
        {
            _testScoresService = testScoreService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenericResponse<TestScoreResponseDTO>), 200)]
        public async Task<IActionResult> GetAddresses(string id)
        {
            var response = await _testScoresService.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }


    }

}
