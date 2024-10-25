using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Services.BasketService;
using Store.Service.Services.BasketService.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasketDto>>GetBasketAsync(string Id)
            =>Ok(await _basketService.GetBasketAsync(Id));
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasketAsync(CustomerBasketDto customerBasketDto)
            =>Ok(await _basketService.UpdateBasketAsync(customerBasketDto));
        [HttpDelete]
        public async Task<ActionResult<CustomerBasketDto>> DeleteBasketAsync(string Id)
            => Ok(await _basketService.DeleteBasketAsync(Id));
    }
}
