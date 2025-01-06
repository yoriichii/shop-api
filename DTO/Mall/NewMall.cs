using System.ComponentModel.DataAnnotations;

namespace shop_api.DTO.Mall
{
    public class NewMall
    {
        public string? Name { get; set; }

        public string? OpenHour { get; set; }

        public string? ClosedHour { get; set; }

        public string? MallAddress { get; set; }

        public string? ContactNumber { get; set; }

        public bool? IsActive { get; set; }

        public int? ShopId { get; set; }

        //public virtual ICollection<UpdateMall> InverseShop { get; set; } = new List<Mall>();

        //public virtual NewMall? Shop { get; set; }
    }
}
