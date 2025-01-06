using System;
using System.Collections.Generic;

namespace shop_api.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ShopTag> ShopTags { get; set; } = new List<ShopTag>();
}
