using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_api.Models;

namespace shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MallController : ControllerBase
    {
        private readonly ShopContext shopContext;

        public MallController(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        [HttpGet]

        public IActionResult MallList()
        {
            var mallList = shopContext.Malls.ToList();
            var response = new { Data = mallList };
            return Ok(response);
        }

    }
}
