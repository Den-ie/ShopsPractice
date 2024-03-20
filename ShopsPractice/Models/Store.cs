using System;
using System.Collections.Generic;

namespace ShopsPractice.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Profile { get; set; }
}
