using System;
using System.Collections.Generic;

namespace shop_api.Models;

public partial class Shop
{
    public int Id { get; set; }

    public int? Contact { get; set; }

    public string? Description { get; set; }

    public string? ShopAddress { get; set; }

    public bool? IsActive { get; set; }

    public int? MallId { get; set; }

    public virtual Mall? Mall { get; set; }

    public virtual ICollection<ShopTag> ShopTags { get; set; } = new List<ShopTag>();
}
