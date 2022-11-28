﻿using Microsoft.AspNetCore.Identity;
using AsyncInnReWrite.Models.DTO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AsyncInnReWrite.Models
{
    public class ApplicationUser : IdentityUser
    {
        private static UserManager<ApplicationUser> userManager;

        public ApplicationUser(UserManager<ApplicationUser> manager)
        {
            userManager = manager;
        }
       public ApplicationUser()
        {

        }
        public static async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            //throw new NotImplementedException();
            var user = new ApplicationUser()
           {
            UserName = data.Username,
            Email = data.Email,
            PhoneNumber = data.PhoneNumber
           };

           var result = await userManager.CreateAsync(user, data.Password);

           if (result.Succeeded)
           {
                return new UserDTO
                {
                    Id = user.Id,
                  Username = user.UserName
               };
           }

            // What about our errors?
           foreach (var error in result.Errors)
           {
               var errorKey =
                   error.Code.Contains("Password") ? nameof(data.Password) :
                   error.Code.Contains("Email") ? nameof(data.Email) :
                   error.Code.Contains("UserName") ? nameof(data.Username) :
                   "";
               modelState.AddModelError(errorKey, error.Description);
           }

           return null;

        }

        public static async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (await userManager.CheckPasswordAsync(user, password))
           {
                return new UserDTO
                {
                    Id = user.Id,
                   Username = user.UserName,
               };
           }

          return null;
        }
    }
}
