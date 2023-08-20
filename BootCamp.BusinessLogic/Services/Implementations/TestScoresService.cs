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
            private readonly UserManager<Trainee> _userManager;
            private readonly IGenericRepo<Test> _genericRepo;
            private readonly MyAppContext _dbContext;


            public TestScoreService(UserManager<Trainee> userManager, IGenericRepo<Test> genericRepo, MyAppContext dbContext)
            {
                this._userManager = userManager;
                this._genericRepo = genericRepo;
                _dbContext = dbContext;
            }


            public List<Test> GetTestScoresByUserId(string traineeId)
            {
<<<<<<< HEAD
                List<Test> testScore = _testScoreRepository.GetTestScoresByUserId(traineeId);

=======
                List<Test> testScore = new(); /*_testScoreRepository.GetTestScoresByUserId(userId);
*/
>>>>>>> Beta
                return testScore;

            }

            public async Task<GenericResponse<TestResultDTO>> PostTestScoreAsync(TestResultDTO testResultDTO)
            {

                if (testResultDTO == null)
                {
                    throw new ArgumentException("Invalid data");
                }

                var trainee = await _userManager.FindByIdAsync(testResultDTO.TraineeId);

                if (trainee == null)
                {
                    throw new ArgumentException("Trainee not found");
                }

                  var test = new Test
                   {
                    StudentId = testResultDTO.StudentId,
                    Score = testResultDTO.Score,
                    CreatedDate = DateTime.Now,
                    CreatedBy = trainee.Id,
                    TestType = testResultDTO.TestType,
                    TraineeId = trainee.Id,
                   };

                await _genericRepo.InsertAsync(test);
                await _dbContext.SaveChangesAsync();

                return GenericResponse<TestResultDTO>.SuccessResponse(testResultDTO, "Test score saved successfully");
            }

        }

    }
}

