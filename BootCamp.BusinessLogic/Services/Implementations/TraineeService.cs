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
            _userManager = userManager;
            _genericRepo = genericRepo;
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


        public async Task<GenericResponse<string>> AddAddressAsync(string traineeId, AddressDTO addressDto)
        {
            var trainee = await _userManager.FindByIdAsync(traineeId);

            if (trainee == null)
            {
                return GenericResponse<string>.ErrorResponse("Trainee not found.", false);
            }

            
            var newAddress = new Address
            {
                PostalCode = addressDto.PostalCode,
                MainAddress = addressDto.MainAddress,
                City = addressDto.City,
                State = addressDto.State,
                Country = addressDto.Country
            };

            trainee.Address.Add(newAddress);

            var result = await _userManager.UpdateAsync(trainee);

            if (result.Succeeded)
            {
                return GenericResponse<string>.SuccessResponse("Address added successfully");
            }
            else
            {
                string errors = result.Errors.Aggregate(string.Empty, (current, error) => current + (error.Description + Environment.NewLine));
                return GenericResponse<string>.ErrorResponse(errors, false);
            }
        }

    }
}
