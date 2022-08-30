﻿using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;

        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            bool isValidUser = false;
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            }
            catch (Exception ex)
            {
            }
            return isValidUser;
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto ApiUserDto)
        {
            var user = _mapper.Map<ApiUser>(ApiUserDto);
            user.UserName = ApiUserDto.Email;

            var result = await _userManager.CreateAsync(user, ApiUserDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }
    }
}
