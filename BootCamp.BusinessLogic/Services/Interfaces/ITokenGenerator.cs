﻿using BootCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.BusinessLogic.Services.Interfaces
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateTokenAsync(Trainee user);
    }
}
