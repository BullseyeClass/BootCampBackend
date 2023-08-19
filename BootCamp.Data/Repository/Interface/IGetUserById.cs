using BootCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Repository.Interface
{
    public interface IGetUserById
    {
        Task<Trainee> GetUserByIdAsync(string userId);
    }
}
