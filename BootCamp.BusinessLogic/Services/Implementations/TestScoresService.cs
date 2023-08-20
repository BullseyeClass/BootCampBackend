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


            public List<Test> GetTestScoresByUserId(Guid userId)
            {
                List<Test> testScore = _testScoreRepository.GetTestScoresByUserId(userId);

                return testScore;

            }

            public void PostTestScore(Test test)
            {

                if (test == null)
                {
                    throw new ArgumentException("Invalid data");
                }

                _testScoreRepository.PostTestScore(test);
            }
        }

    }
}

