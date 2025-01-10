using System.ComponentModel.DataAnnotations;

namespace shop_api.DTO.Mall

{
    public class NewMall
    {
        [Required(ErrorMessage = "Name is Required")]
        public string? Name { get; set; }

        public string? OpenHour { get; set; }

        public string? ClosedHour { get; set; }

        public string? MallAddress { get; set; }

        public string? ContactNumber { get; set; }

        public bool? IsActive { get; set; }

        //public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
