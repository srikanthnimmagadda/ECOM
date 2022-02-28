using System.ComponentModel.DataAnnotations;

namespace ECOM.Core.Entities.Identity
{
    public class Address
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string ApplicationUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ApplicationUser ApplicationUser { get; set; }
    }
}