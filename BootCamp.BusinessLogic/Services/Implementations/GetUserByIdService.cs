using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.BusinessLogic.Services.Implementations
{
    public class GetUserByIdService: IGetUserByIdService
    {
        private readonly IGetUserById _getUserById;

        public GetUserByIdService(IGetUserById getUserById)
        {
            _getUserById = getUserById;
        }

        public async Task<Trainee> GetUserByIdAsync(string userId)
        {
            return await _getUserById.GetUserByIdAsync(userId.ToString());
        }
    }
}
