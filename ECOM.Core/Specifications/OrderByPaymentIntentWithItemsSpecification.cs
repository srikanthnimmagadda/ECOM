using ECOM.Core.Entities.OrderAggregate;

namespace ECOM.Core.Specifications
{
    public class OrderByPaymentIntentWithItemsSpecification : BaseSpecifcation<Order, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentIntentId"></param>
        public OrderByPaymentIntentWithItemsSpecification(string paymentIntentId)
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}