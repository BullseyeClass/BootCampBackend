using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Interface;
using BootCamp.DTO.Response;
using BootCamp.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BootCamp.BusinessLogic.Services.Implementations.TestScoresService;
using BootCamp.DTO.Request;
using Microsoft.EntityFrameworkCore;
using BootCamp.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace BootCamp.BusinessLogic.Services.Implementations
{
    public class TestScoresService
    {

        public class TestScoreService : ITestScoresService
        {
            private readonly ITestScoreRepository _testScoreRepository;
            private readonly MyAppContext _dbContext;


            public TestScoreService(UserManager<Trainee> userManager, ITestScoreRepository testScoreRepository, MyAppContext dbContext)
            {
                _testScoreRepository = testScoreRepository;
                _dbContext = dbContext;
            }


            public List<Test> GetTestScoresByUserId(Guid userId)
            {
                List<Test> testScore = _testScoreRepository.GetTestScoresByUserId(userId);

                return testScore;

            }

            public async Task<GenericResponse<TestResultDTO>> PostTestScoreAsync(TestResultDTO testResultDTO)
            {

                if (testResultDTO == null)
                {
                    throw new ArgumentException("Invalid data");
                }

                var testScoreEntity = new Test
                {
                    StudentId = testResultDTO.StudentId,
                    Score = testResultDTO.Score,
                    CreatedDate = testResultDTO.CreatedDate,
                    CreatedBy = testResultDTO.CreatedBy,
                    TestType = testResultDTO.TestType,
                    TraineeId = testResultDTO.TraineeId,
                    UpdatedDate = testResultDTO.UpdatedDate,
                };

                await _testScoreRepository.PostTestScoreAsync(testScoreEntity);
                await _dbContext.SaveChangesAsync();

                return GenericResponse<TestResultDTO>.SuccessResponse(testResultDTO, "Test score saved successfully");
            }

        }

    }
}

