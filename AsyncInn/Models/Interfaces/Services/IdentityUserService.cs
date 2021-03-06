﻿using AsyncInn.Models.API;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> userManager;
        private JwtTokenService tokenService;

        public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
        {
            userManager = manager;
            tokenService = jwtTokenService;
        }

        public async Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.Phone
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRolesAsync(user, data.Roles);
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
                };
            }

            foreach(var error in result.Errors)
            {
                var errorKey = 
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("UserName") ? nameof(data.Username) : "";

                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }

        public async Task<UserDTO> Authenticate(string userName, string password)
        {
            var user = await userManager.FindByNameAsync(userName);

            if(await userManager.CheckPasswordAsync(user, password))
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
                };
            }
            return null;
        }

        public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            return new UserDTO
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5))
            };
        }
    }
}
