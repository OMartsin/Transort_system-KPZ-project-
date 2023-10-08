using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class DriverContract
{
    public int ContractId { get; set; }

    public int ContractNumber { get; set; }

    public DateOnly ContractIssueDate { get; set; }

    public DateOnly? ContractExpiryDate { get; set; }

    public int ContractDriverId { get; set; }

    public virtual Driver ContractDriver { get; set; } = null!;
}
