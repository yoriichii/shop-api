using System.ComponentModel.DataAnnotations;

namespace shop_api.DTO.Shop
{
    public class NewShop
    {
        [Required(ErrorMessage = "Contact is required")]
        public string? Contact { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "ShopAddress is required")]
        public string? ShopAddress { get; set; }

        public bool? IsActive { get; set; }
    }
}
