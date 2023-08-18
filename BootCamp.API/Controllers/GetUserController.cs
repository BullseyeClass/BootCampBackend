using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BootCamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {

        private readonly MyAppContext _appContext;

        public GetUserController(MyAppContext myAppContext)
        {
            _appContext = myAppContext;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Trainee>> GetUserById(string id)
        {
            
            var trainee = await _appContext.Users.FindAsync(id);

            if (trainee == null)
            {
                return NotFound();
            }

            return trainee; 
        }


    }
}
