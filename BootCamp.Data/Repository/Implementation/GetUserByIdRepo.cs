using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Repository.Implementation
{
    public class GetUserByIdRepo: IGetUserById
    {

        private readonly UserManager<Trainee> _userManager;

        public GetUserByIdRepo(UserManager<Trainee> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Trainee> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

    }
}
