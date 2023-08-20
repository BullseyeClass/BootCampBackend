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

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(GenericResponse<TestScoreResponseDTO>), 200)]
        public IActionResult GetTestScoresByUserId(Guid userId)
        {
            var testScores =  _testScoresService.GetTestScoresByUserId(userId);

            if (testScores == null || testScores.Count == 0)
            {
                return NotFound();
            }

            return Ok(testScores);
        }

        [HttpPost("{userId}")]
        [ProducesResponseType(typeof(GenericResponse<TestResultDTO>), 200)]
        public IActionResult PostTestScore([FromBody]Test test)
        {
               var testScores = _testScoresService.PostTestScore(test);

                return Ok("Test score saved successfully");
            
            
               
            
        }
    }
}
