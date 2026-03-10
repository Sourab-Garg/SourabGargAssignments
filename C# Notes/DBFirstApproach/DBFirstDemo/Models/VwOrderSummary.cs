using System;
using System.Collections.Generic;

namespace DBFirstDemo.Models;

public partial class VwOrderSummary
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string CompanyName { get; set; } = null!;

    public decimal? TotalAmount { get; set; }
}
