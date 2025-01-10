using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_api.DTO.Tag;
using shop_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ShopContext shopContext;

        public TagController(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        [HttpGet]

        public IActionResult GetTag()
        {
            var getTag = shopContext.Tags.ToList();
            var response = new { Data = getTag };
            return Ok(response);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetTagById(int id)
        {
            var tag = shopContext.Tags.Find(id);
            if(tag == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(tag);
        }

        [HttpPost]

        public IActionResult NewTag(NewTag newTag)
        {
            if (newTag == null)
            {
                return BadRequest();
            }

            var createTag = new Tag()
            {
                Name = newTag.Name,
            };
        
            shopContext.Tags.Add(createTag);
            shopContext.SaveChanges();
            return Ok(createTag);
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateTag(int id, UpdateTag updateTag)
        {
            var update = shopContext.Tags.Find(id); 
            if(update == null)
            {
                return BadRequest("Not Found");
            }

            update.Name = updateTag.Name;
            shopContext.SaveChanges();
            return Ok(update);
        }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteTag(int id)
        {
            var deleteTag = shopContext.Tags.Find(id);
            if (deleteTag == null)
            {
                return BadRequest("Not Found");
            }
            shopContext.Tags.Remove(deleteTag); 
            shopContext.SaveChanges();
            return Ok(deleteTag);
        }

    }
}
