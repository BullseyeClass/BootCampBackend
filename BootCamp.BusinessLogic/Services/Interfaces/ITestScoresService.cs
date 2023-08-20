using BootCamp.Data.Entities;
using BootCamp.DTO;
using BootCamp.DTO.Request;
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
        Task<Test> GetTestScoresByUserId(Guid traineeId);
        Task<GenericResponse<TestResultDTO>> PostTestScoreAsync(TestResultDTO testResultDTO);

    }
}
