using AutoMapper;
using ECOM.API.Dto;
using ECOM.Core.Entities;
using ECOM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.API.Controllers
{
    public class BasketController : ApiBaseController
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketService"></param>
        /// <param name="mapper"></param>
        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _mapper = mapper;
            _basketService = basketService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketService.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
           // var customerBasket = _mapper.Map<CustomerBasket>(basket);
            var updatedBasket = await _basketService.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketService.DeleteBasketAsync(id);
        }
    }
}
