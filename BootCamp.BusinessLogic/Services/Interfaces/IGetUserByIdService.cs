using BootCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.BusinessLogic.Services.Interfaces
{
    public interface IGetUserByIdService
    {
        Task<Trainee> GetUserByIdAsync(string userId);
    }
}
