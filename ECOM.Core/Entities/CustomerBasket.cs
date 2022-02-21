namespace ECOM.Core.Entities
{
    public class CustomerBasket
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerBasket() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public CustomerBasket(string id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

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