using System;
using System.Collections.Generic;

namespace shop_api.Models;

public partial class Shop
{
    public int Id { get; set; }

    public string? Contact { get; set; }

    public string? Description { get; set; }

    public string? ShopAddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual Mall? Mall { get; set; }
}
