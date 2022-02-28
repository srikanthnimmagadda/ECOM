using Microsoft.AspNetCore.Identity;

namespace ECOM.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Address Address { get; set; }
    }
}
