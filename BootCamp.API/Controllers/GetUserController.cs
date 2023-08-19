using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Implementation;
using BootCamp.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TraineeDTO = BootCamp.DTO.Response.TraineeDTO;

namespace BootCamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {

        private readonly MyAppContext _dbContext;

        public GetUserController(MyAppContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TraineeDTO>> GetUserById(string id)
        {
            var trainee = await _dbContext.Users
                .Include(t => t.PhoneNumbers)
                .Include(t => t.Address)
                .Include(t => t.Tests)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainee == null)
            {
                return NotFound();
            }

            var details = new TraineeDTO
            {
                FirstName = trainee.FirstName,
                LastName = trainee.LastName,
                MiddleName = trainee.MiddleName,
                PhoneNumbers = trainee.PhoneNumbers.Select(p => new PhoneNumberDTO
                {
                    Extension = p.Extension,
                    Number = p.Number
                }).ToList(),

                Address = trainee.Address.Select(a => new AddressDTO
                {
                    PostalCode = a.PostalCode,
                    MainAddress = a.MainAddress,
                    City = a.City,
                    State = a.State,
                    Country = a.Country
                }).ToList(),
                Tests = trainee.Tests.Select(t => new TestScoreResponseDTO
                {
                    Score = t.Score,
                    TestType = t.TestType,
                    IsPassed = t.IsPassed
                }).ToList(),
            };
            return Ok(details);



            //    var trainee = await _dbContext.Users
            //.FirstOrDefaultAsync(t => t.Id == id);

            //    if (trainee == null)
            //    {
            //        return NotFound();
            //    }

            //    // Explicitly load related entities
            //    await _dbContext.Entry(trainee)
            //        .Collection(t => t.PhoneNumbers)
            //        .LoadAsync();

            //    await _dbContext.Entry(trainee)
            //        .Collection(t => t.Address)
            //        .LoadAsync();

            //    await _dbContext.Entry(trainee)
            //        .Collection(t => t.Tests)
            //        .LoadAsync();

            //    var traineeDTO = new TraineeDTO
            //    {
            //        FirstName = trainee.FirstName,
            //        LastName = trainee.LastName,
            //        MiddleName = trainee.MiddleName,
            //        PhoneNumbers = trainee.PhoneNumbers.Select(p => new PhoneNumberDTO
            //        {
            //            Extension = p.Extension,
            //            Number = p.Number,
            //            UserId = p.UserId,
            //        }).ToList(),
            //        Address = trainee.Address.Select(a => new AddressDTO
            //        {
            //            PostalCode = a.PostalCode,
            //            MainAddress = a.MainAddress,
            //            City = a.City,
            //            State = a.State,
            //            Country = a.Country
            //        }).ToList(),
            //        Tests = trainee.Tests.Select(t => new TestScoreResponseDTO
            //        {
            //            Score = t.Score,
            //            TestType = t.TestType,
            //            IsPassed = t.IsPassed
            //        }).ToList()
            //    };

            //    return traineeDTO;
        }

    }
}
