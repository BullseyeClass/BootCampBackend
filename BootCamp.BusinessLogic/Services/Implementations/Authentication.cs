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
    public class Authentication : IAuthentication
    {
        private readonly UserManager<Trainee> _userManager;
        private readonly IGenericRepo<Trainee> _genericTraineeRepo;
        private readonly ITokenGenerator _tokenGenerator;

        public Authentication(UserManager<Trainee> userManager, IGenericRepo<Trainee> genericTraineeRepo, ITokenGenerator tokenGenerator)
        {
            this._userManager = userManager;
            this._genericTraineeRepo = genericTraineeRepo;
            this._tokenGenerator = tokenGenerator;
        }

        public async Task<GenericResponse<LoginResponseDTO>> LoginAsync(LoginRequestDTO userRequest)
        {
            var user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequest.Password))
                {
                    if (user.EmailConfirmed)
                    {
                        var userResponse = new LoginResponseDTO
                        {
                            Email = user.Email,
                            FullName = $"{user.FirstName} {user.LastName}",
                            Id = user.Id,
                            Token = await _tokenGenerator.GenerateTokenAsync(user)
                        };

                        return GenericResponse<LoginResponseDTO>.SuccessResponse(userResponse, "Login Successful");
                    }
                    return GenericResponse<LoginResponseDTO>.ErrorResponse("Kindly verify your email address to login", false);
                }
                return GenericResponse<LoginResponseDTO>.ErrorResponse("Invalid credentials", false);
            }
            return GenericResponse<LoginResponseDTO>.ErrorResponse("Invalid Credentials", false);

        }

    }
}
