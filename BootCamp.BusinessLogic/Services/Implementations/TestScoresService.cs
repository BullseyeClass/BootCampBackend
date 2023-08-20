﻿using BootCamp.BusinessLogic.Services.Interfaces;
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

            public async Task<GenericResponse<TestResultDTO>> PostTestScoreAsync(TestResultDTO testResultDTO)
            {

                if (testResultDTO == null)
                {
                    throw new ArgumentException("Invalid data");
                }

               var testScore = await _testScoreRepository.PostTestScoreAsync(testResultDTO);
                return testScore;
            }
        }

    }
}

