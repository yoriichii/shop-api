using System.Collections.Generic;
namespace shop_api.DTO
{
    public class AddShopTags
    {
        public int ShopId { get; set; }
        public List<int> TagIds { get; set; }
    }
}
