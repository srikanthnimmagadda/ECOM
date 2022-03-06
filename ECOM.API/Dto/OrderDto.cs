namespace ECOM.API.Dto
{
    public class OrderDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string BasketId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DeliveryMethodId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AddressDto ShipToAddress { get; set; }
    }
}