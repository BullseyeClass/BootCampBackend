﻿using BootCamp.BusinessLogic.Services.Implementations;
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

        [HttpGet("{TraineeId)}")]
        [ProducesResponseType(typeof(GenericResponse<TestScoreResponseDTO>), 200)]
        public IActionResult GetTestScoresByUserId(string traineeId)
        {
            var testScores = _testScoresService.GetTestScoresByUserId(traineeId);

            if (testScores == null || testScores.Count == 0)
            {
                return NotFound();
            }

            var testScoreDtos = testScores.Select(ts => new TestScoreResponseDTO
            {
                Id = ts.Id.ToString(),
                TestType = ts.TestType,
                Score = ts.Score,
                IsPassed = ts.IsPassed
            }).ToList();

            return Ok(testScoreDtos);
        }

        [HttpPost("post")]
        [ProducesResponseType(typeof(GenericResponse<TestResultDTO>), 200)]
        public async Task<IActionResult> PostTestScore([FromBody]TestResultDTO testResultDTO)
        {
            var testScores = await _testScoresService.PostTestScoreAsync(testResultDTO);

            if(testScores == null)
            {
                return BadRequest();
            }
                return Ok("Test score saved successfully");
 
               
            
        }
    }
}
