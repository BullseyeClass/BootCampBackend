using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Data.Repository.Implementation
{
    public class GetUserRepo : IGetUserRepo
    {
        private readonly MyAppContext _dbContext;

        public GetUserRepo(MyAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Trainee GetUserData(string userId)
        {
            using (_dbContext)
            {
                return _dbContext.Users
                    .Include(u => u.PhoneNumbers)
                    .Include(u => u.Address)
                    .Include(u => u.Tests)
                    .FirstOrDefault(predicate: u => u.Id == userId);
            }
        }
    }
}
