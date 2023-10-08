using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class DeliveryLog
{
    public int DeliveryLogId { get; set; }

    public int TripId { get; set; }

    public string LogOperationName { get; set; } = null!;

    public string LogOperationDescription { get; set; } = null!;

    public string? LogOperationLocationCity { get; set; }

    public DateTime OperationDateTime { get; set; }

    public virtual Trip Trip { get; set; } = null!;
}
