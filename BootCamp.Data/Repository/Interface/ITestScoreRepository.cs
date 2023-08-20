using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Repository.Interface
{
    public interface ITestScoreRepository
    {
        List<Test> GetTestScoresByUserId(Guid userId);
        void PostTestScore(Test test);
    }
}
