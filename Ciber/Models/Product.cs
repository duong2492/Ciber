using System;
using System.Collections.Generic;

namespace Ciber.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int? ProductCategoryId { get; set; }

    public int? Price { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ProductCategory? ProductCategory { get; set; }
}
