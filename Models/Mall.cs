using System;
using System.Collections.Generic;

namespace shop_api.Models;

public partial class Mall
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LocationUrl { get; set; }

    public string? OpenHour { get; set; }

    public string? ClosedHour { get; set; }

    public string? MallAddress { get; set; }

    public string? ContactNumber { get; set; }

    public bool? IsActive { get; set; }

    public string? BackgroundPath { get; set; }

    public virtual Shop IdNavigation { get; set; } = null!;
}
