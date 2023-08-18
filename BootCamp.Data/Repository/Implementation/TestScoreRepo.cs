using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Interface;
using BootCamp.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Where(ts => ts.TraineeId == userId.ToString())
                .ToList(); 
        }
    }
}
