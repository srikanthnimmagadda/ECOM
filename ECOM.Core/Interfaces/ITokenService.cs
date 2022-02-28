
using ECOM.Core.Entities.Identity;

namespace ECOM.Core.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string CreateToken(ApplicationUser user);
    }
}