using Microsoft.AspNetCore.Mvc;
using TalabatG02.APIs.Errors;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;

namespace TalabatG02.APIs.Controllers
{

    public class BasketController : ApiBaseController
    {
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        //public IBasketRepository GetBasketRepository()
        //{
        //    return basketRepository;
        //}

        [HttpGet]//{{baseurl}}api/Basket?id=basket1
        public async Task<ActionResult<CustomerBasket>> GetCustomerBasket(string id)
        {
            var basket = await basketRepository.GetBasketAsync(id);
            return basket is null ? new CustomerBasket(id) : basket;
        }
        [HttpPost]//{{baseurl}}api/Basket
        public async Task<ActionResult<CustomerBasket>> UpdatePasket(CustomerBasket basket)
        {
            var CreatedOrUpdatedBasket = await basketRepository.UpdateBasketAsync(basket);
            if (CreatedOrUpdatedBasket is null) return BadRequest(new ApiErrorResponse(400));
            return Ok(CreatedOrUpdatedBasket);

        }
        [HttpDelete]//{{baseurl}}api/Basket?id=basket1
        public async Task<ActionResult<bool>> DeletePasket(string id)
        {
            return await basketRepository.DeleteBasketAsync(id);

        }

    }
}
