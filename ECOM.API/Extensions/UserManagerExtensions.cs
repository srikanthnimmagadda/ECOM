using System.Security.Claims;
using ECOM.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Extensions
{
    public static class UserManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<ApplicationUser> FindByEmailWithAddressAsync(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<ApplicationUser> FindByEmailFromClaimsPrinciple(this UserManager<ApplicationUser> input, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);
            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}