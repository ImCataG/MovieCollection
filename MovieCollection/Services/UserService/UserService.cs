using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieCollection.Models;
using MovieCollection.Models.Authentication;

namespace MovieCollection.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<bool> RegisterNew(Register r, string role)
        {
            var userExists = await _userManager.FindByEmailAsync(r.Email);
            if (userExists != null)
            {
                return false;
            }

            IdentityUser user = new()
            {
                Email = r.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = r.Username
            };
            var result = await _userManager.CreateAsync(user, r.Password);
            if (!result.Succeeded)
            {
                return false;
            }


            var result2 = await _userManager.AddToRoleAsync(user, role);
            if (!result2.Succeeded)
            {
                return false;
            }


            return true;
        }
    }
}
