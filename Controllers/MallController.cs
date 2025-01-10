using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_api.DTO.Mall;
using shop_api.DTO.Shop;
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

        [HttpGet("{id:int}")]

        public IActionResult GetMallById(int id)
        {
            var getMallById = shopContext.Malls.Find(id);
            if (getMallById == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(getMallById);
        }

        [HttpPost]

        public IActionResult CreateMall(NewMall newMall)
        {
            if (newMall == null)
            {
                return BadRequest("Mall data is invalid.");
            }
            var createMall = new Mall()
            {
                Name = newMall.Name,
                OpenHour = newMall.OpenHour,
                ClosedHour = newMall.ClosedHour,
                MallAddress = newMall.MallAddress,
                ContactNumber = newMall.ContactNumber,
                IsActive = newMall.IsActive,
            };
            shopContext.Malls.Add(createMall);
            shopContext.SaveChanges();
            return Ok(createMall);
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateMall(int id, UpdateMall updateMall)
        {
            var update = shopContext.Malls.Find(id);
            if(updateMall == null)
            {
                return BadRequest();
            }

            update.Name = updateMall.Name;
            update.OpenHour = updateMall.OpenHour;
            update.ClosedHour = updateMall.ClosedHour;
            update.MallAddress = updateMall.MallAddress;
            update.ContactNumber = updateMall.ContactNumber;
            update.IsActive = updateMall.IsActive;
            shopContext.SaveChanges();
            return Ok(update);
           }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteMall(int id)
        {
            var deleteMall = shopContext.Malls.Find(id);
            if(deleteMall == null)
            {
                return BadRequest("Not Found");
            }
            shopContext.Malls.Remove(deleteMall);
            shopContext.SaveChanges();
            return Ok(deleteMall);
        }


    }
}
