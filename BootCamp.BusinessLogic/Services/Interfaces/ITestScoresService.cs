using BootCamp.Data.Entities;
using BootCamp.DTO;
using BootCamp.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.BusinessLogic.Services.Interfaces
{
    public interface ITestScoresService
    {
        List<Test> GetTestScoresByUserId(Guid userId);
        void PostTestScore(Test test);
    }
}
