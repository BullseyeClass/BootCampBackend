using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.BusinessLogic.Services.Implementations
{
    public class TestScoresService
    {

    public class TestScoreService : ITestScoresService
        {
            private readonly ITestScoreRepository _testScoreRepository;

            public TestScoreService(ITestScoreRepository testScoreRepository)
            {
                _testScoreRepository = testScoreRepository;
            }


            public List<Test> GetTestScoresByUserId(string userId)
            {
                List<Test> testScore = _testScoreRepository.GetTestScoresByUserId(userId);

                return testScore;

            }

        }
    }
}
