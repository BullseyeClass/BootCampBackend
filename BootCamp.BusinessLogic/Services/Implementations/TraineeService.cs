using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using BootCamp.Data.Repository.Interface;
using BootCamp.DTO;
using BootCamp.DTO.Request;
using BootCamp.DTO.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.BusinessLogic.Services.Implementations
{

    public class TraineeService : ITraineeService
    {
        private readonly UserManager<Trainee> _userManager;
        private readonly IGenericRepo<Trainee> _genericRepo;

        public TraineeService(UserManager<Trainee> userManager, IGenericRepo<Trainee> genericRepo)
        {
            this._userManager = userManager;
            this._genericRepo = genericRepo;
        }


        public async Task<GenericResponse<TraineeRegistrationResponseDTO>> RegistrationAsync(TraineeRegistrationDTO traineeRegistrationDTO)
        {
            Trainee trainee = new Trainee()
            {
                Email = traineeRegistrationDTO.Email,
                UserName = traineeRegistrationDTO.Email.Split('@')[0], 
                EmailConfirmed = true
            };

            IdentityResult result = await _userManager.CreateAsync(trainee, traineeRegistrationDTO.Password);

            if (result.Succeeded)
            {
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(trainee);
                var registrationResult = new TraineeRegistrationResponseDTO()
                {
                    Id = trainee.Id,
                    Email = traineeRegistrationDTO.Email,
                    FullName = $"{trainee.FirstName} {trainee.LastName}", 
                    Token = emailToken
                };

                return GenericResponse<TraineeRegistrationResponseDTO>.SuccessResponse(registrationResult, "Registration successful");
            }
            else
            {
                string errors = result.Errors.Aggregate(string.Empty, (current, error) => current + (error.Description + Environment.NewLine));
                return GenericResponse<TraineeRegistrationResponseDTO>.ErrorResponse(errors, false);
            }
        }

    }
}
