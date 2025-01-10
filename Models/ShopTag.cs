using System;
using System.Collections.Generic;

namespace shop_api.Models;

public partial class ShopTag
{
    public int Id { get; set; }

    public int? ShopId { get; set; }

    public int? TagId { get; set; }

    public virtual Shop? Shop { get; set; } = null!;

    public virtual Tag? Tag { get; set; } = null!;
}
