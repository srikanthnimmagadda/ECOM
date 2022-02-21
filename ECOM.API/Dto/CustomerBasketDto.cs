using System.ComponentModel.DataAnnotations;

namespace ECOM.API.Dto
{
    public class CustomerBasketDto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BasketItemDto> Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? DeliveryMethodId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ShippingPrice { get; set; }
    }
}
