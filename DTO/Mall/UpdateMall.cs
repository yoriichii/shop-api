using System.ComponentModel.DataAnnotations;

namespace shop_api.DTO.Mall
{
    public class UpdateMall
    {

        [Required(ErrorMessage = "Name is requied")]
        public string? Name { get; set; }

        public string? LocationUrl { get; set; }

        [Required(ErrorMessage = "OpenHour is requied")]
        public string? OpenHour { get; set; }

        [Required(ErrorMessage = "ClosedHour is requied")]
        public string? ClosedHour { get; set; }

        public string? MallAddress { get; set; }

        public string? ContactNumber { get; set; }

        public bool? IsActive { get; set; }

        public string? BackgroundPath { get; set; }
    }
}
