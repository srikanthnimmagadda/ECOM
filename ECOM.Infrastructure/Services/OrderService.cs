using ECOM.Core.Entities;
using ECOM.Core.Entities.OrderAggregate;
using ECOM.Core.Interfaces;
using ECOM.Core.Specifications;

namespace ECOM.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketService"></param>
        /// <param name="unitOfWork"></param>
        public OrderService(IBasketService basketService,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _basketService = basketService;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail,
            int delieveryMethodId,
            string basketId,
            OrderAddress shippingAddress)
        {
            // get basket from repo
            var basket = await _basketService.GetBasketAsync(basketId);

            // get items from the product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product, int>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            // get delivery method from repo
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod, int>().GetByIdAsync(delieveryMethodId);

            // calc subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            // check to see if order exists
            var spec = new OrderByPaymentIntentWithItemsSpecification(basket.PaymentIntentId);
            var existingOrder = await _unitOfWork.Repository<Order, int>().GetEntityWithSpec(spec);

            // create order
            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal, basket.PaymentIntentId);
            _unitOfWork.Repository<Order, int>().Add(order);

            if (existingOrder != null)
            {
                _unitOfWork.Repository<Order, int>().Delete(existingOrder);
                //await _paymentService.CreateOrUpdatePaymentIntent(basket.PaymentIntentId);
            }

            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;

            return order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod, int>().ListAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="buyerEmail"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);
            return await _unitOfWork.Repository<Order, int>().GetEntityWithSpec(spec);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buyerEmail"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
            return await _unitOfWork.Repository<Order, int>().ListAsync(spec);
        }
    }
}
