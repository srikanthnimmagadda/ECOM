using ECOM.Core.Entities.OrderAggregate;

namespace ECOM.Core.Specifications
{
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecifcation<Order, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        public OrdersWithItemsAndOrderingSpecification(int id, string email)
            : base(o => o.Id == id && o.BuyerEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DeliveryMethod);
        }
    }
}
