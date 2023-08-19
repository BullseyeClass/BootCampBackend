//using BootCamp.Data.Repository.Implementation;
using BootCamp.DTO.Response;
using BootCamp.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCamp.Data.Repository.Implementation;
using BootCamp.Data.Entities;
using BootCamp.BusinessLogic.Services.Interfaces;

namespace BootCamp.BusinessLogic.Services.Implementations
{
    public class GetUserService: IGetUserService
    {
        private readonly GetUserRepo _getUserRepo;

        public GetUserService(GetUserRepo getUserRepo)
        {
            _getUserRepo = getUserRepo;
        }

        public Trainee GetUser(string userId)
        {
            Trainee user = _getUserRepo.GetUserData(userId);

            return user;

        }

    }
}
