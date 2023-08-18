using BootCamp.Data.Entities;
using BootCamp.DTO.Response;
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
    }
}
