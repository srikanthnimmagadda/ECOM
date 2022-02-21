using ECOM.Core.Entities;

namespace ECOM.Core.Interfaces
{
    public interface IBasketService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        Task<CustomerBasket> GetBasketAsync(string basketId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
