using System.ComponentModel.DataAnnotations;

namespace ECOM.API.Dto
{
    public class AddressDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string ZipCode { get; set; }
    }
}