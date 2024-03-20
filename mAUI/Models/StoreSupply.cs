using System;
using System.Collections.Generic;

namespace mAUI.Models;

public partial class StoreSupply
{
    public int SupplyId { get; set; }

    public int? StoreId { get; set; }

    public int? SupplierId { get; set; }

    public decimal? SupplyCost { get; set; }

    public virtual Store? Store { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
