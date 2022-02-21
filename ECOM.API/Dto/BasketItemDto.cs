using System.ComponentModel.DataAnnotations;

namespace ECOM.API.Dto
{
    public class BasketItemDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string PictureUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Brand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Type { get; set; }
    }
}
