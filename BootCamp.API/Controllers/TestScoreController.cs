using BootCamp.BusinessLogic.Services.Implementations;
using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.DTO.Response;
using BootCamp.DTO;
using Microsoft.AspNetCore.Mvc;
using BootCamp.Data.Entities;
using System.Security.Claims;

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
        public async Task<IActionResult> GetTestScore(string id)
        {
            var response = await _testScoresService.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }



        [HttpPost("post")]
        [ProducesResponseType(typeof(GenericResponse<TestResultDTO>), 200)]
        public async Task<IActionResult> PostTestScore([FromBody] TestResultDTO testResultDTO)
        {
            //var traineeId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            //testResultDTO.TraineeId = traineeId;
            var testScores = await _testScoresService.PostTestScoreAsync(testResultDTO);
            if (testScores == null)
            {
                return BadRequest();
            }
            return Ok("Test score saved successfully");

        }
    }
}
