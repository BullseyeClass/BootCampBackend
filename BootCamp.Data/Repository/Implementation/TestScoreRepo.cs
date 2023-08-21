using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BootCamp.Data.Repository.Implementation
{

    public class TestScoreRepository : ITestScoreRepository
    {
        private readonly MyAppContext _dbContext;

        public TestScoreRepository(MyAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Test> GetTestScoresByUserId(string traineeId)
        {
            return _dbContext.Tests
                .Where(ts => ts.TraineeId == traineeId)
                .ToList();
        }

        public async Task PostTestScoreAsync(Test testScoreEntity)
        {
            await _dbContext.Tests.AddAsync(testScoreEntity);
            await _dbContext.SaveChangesAsync();
        }

    }

}
