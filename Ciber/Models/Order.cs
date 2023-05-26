using System;
using System.Collections.Generic;

namespace Ciber.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public string? OrderName { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? Amount { get; set; }

    public int? Status { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
    public DateTime? OrderDate { get; set; }
}
