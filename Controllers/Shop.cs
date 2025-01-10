using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.DTO.Shop;
using shop_api.Models;

namespace shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopContext shopContext;

        public ShopController(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        [HttpGet]
        public IActionResult GetShop()
        {
            var shops = shopContext.Shops
                .Include(s => s.ShopTags)
                    .ThenInclude(st => st.Tag)
                .Select(s => new
                {
                    s.Id,
                    s.Description,
                    s.Contact,
                    s.ShopAddress,
                    s.IsActive,  
                    TagList = s.ShopTags.Select(st => new
                    {
                        st.Tag.Id,
                        st.Tag.Name
                    }).ToList()
                })
                .ToList();

            var response = new { Data = shops };
            return Ok(response);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetShop(int id)
        {
            var getShopById = shopContext.Shops.Find(id);
            if (getShopById == null)
            {
                return BadRequest();
            }
            return Ok(getShopById);
        }

        [HttpPost]

        public IActionResult CreateShop(NewShop newShop)
        {
            if (newShop == null)
            {
                return BadRequest("Shop data is invalid.");
            }

            //check if dublicate can not create 
            //var existingShop = shopContext.Shops.FirstOrDefault(s => s.Contact == newShop.Contact);
            //if (existingShop != null)
            //{
            //    return Conflict("A shop with the same Contact already exists.");
            //}

            var createShop = new Shop()
            {
                //Contact = newShop.Contact,
                Description = newShop.Description,
                ShopAddress = newShop.ShopAddress,
                IsActive = newShop.IsActive,
            };
            shopContext.Shops.Add(createShop);
            shopContext.SaveChanges();
            return Ok(createShop);
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateShop(int id, UpdateShop updateShop)
        {
            var update = shopContext.Shops.Find(id);
            if (updateShop == null)
            {
                return BadRequest("not found");
            }
            //check if dublicate can not update 
            //var existingShop = shopContext.Shops.FirstOrDefault(s => s.Contact == updateShop.Contact);
            //if (existingShop != null)
            //{
            //    return Conflict("A shop with the same Contact already exists.");
            //}

            //update.Contact = updateShop.Contact;
            update.Description = updateShop.Description;
            update.ShopAddress = updateShop.ShopAddress;
            update.IsActive = updateShop.IsActive;
            shopContext.SaveChanges();
            return Ok(update);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteShop(int id)
        {
            var deleteShop = shopContext.Shops.Find(id);
            if (deleteShop == null)
            {
                return NotFound();
            }
            //deleteShop.Mall = null;
            shopContext.Shops.Remove(deleteShop);
            shopContext.SaveChanges();
            return Ok("Success");
        }    

    }
}

//test commit