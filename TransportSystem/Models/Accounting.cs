using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Accounting
{
    public int OperationId { get; set; }

    public string OperationName { get; set; } = null!;

    public string? OperationDescription { get; set; }

    public int OperationTotal { get; set; }

    public int OperationAgentId { get; set; }

    public DateOnly OperationDate { get; set; }

    public virtual Agent OperationAgent { get; set; } = null!;
}
