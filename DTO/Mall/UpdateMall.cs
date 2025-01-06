using System.ComponentModel.DataAnnotations;

namespace shop_api.DTO.Mall
{
    public class UpdateMall
    {
        public string? Name { get; set; }

        public string? OpenHour { get; set; }

        public string? ClosedHour { get; set; }

        public string? MallAddress { get; set; }

        public string? ContactNumber { get; set; }

        public bool? IsActive { get; set; }

        public int? ShopId { get; set; }

        //public virtual ICollection<Mall> InverseShop { get; set; } = new List<Mall>();

        //public virtual Mall? Shop { get; set; }
    }
}
