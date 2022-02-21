using System.Text.Json;
using ECOM.Core.Entities;
using ECOM.Core.Interfaces;
using StackExchange.Redis;

namespace ECOM.Infrastructure.Services
{
    public class BasketService : IBasketService
    {
        private readonly IDatabase _database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="redis"></param>
        public BasketService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database
                .StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}