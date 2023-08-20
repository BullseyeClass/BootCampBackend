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

        public List<Test> GetTestScoresByUserId(Guid userId)
        {
            return _dbContext.Tests
                .Where(ts => ts.Id == userId)
                .ToList();
        }

        public void PostTestScore(Test test)
        {
            var testScore = new Test
            {
                StudentId = test.StudentId,
                Score = (int)test.Score,
                CreatedOn = (DateTime)test.CreatedOn,
                CreatedBy = (string)test.CreatedBy
            };

            _dbContext.Tests.Add(testScore);
            _dbContext.SaveChanges();
        }
    }
    
}
