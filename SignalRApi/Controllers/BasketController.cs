using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }



        [HttpGet]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.TGetBAsketByMenuTableNumber(id);
            return Ok(values);
        }


        [HttpGet]
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
           using  var context = new SignalRContext();
            var values  = context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableId==id).Select(z=> new ResultBasketListWithProducts
            {
               BasketId = z.BasketId,
               Count = z.Count,
               MenuTableId= z.MenuTableId,
               Price     = z.Price,
               TotalPrice = z.TotalPrice,
               ProductName= z.Product.ProductName

            }).ToList();
            return Ok(values);       
        }
    }
}
