using System;
using System.Collections.Generic;

namespace ShopsPractice.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string? FullName { get; set; }

    public string? MadeDate { get; set; }

    public string? Storing { get; set; }
}
