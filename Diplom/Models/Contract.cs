using System;
using System.Collections.Generic;

namespace Diplom.Models;

public partial class Contract
{
    public int IdContract { get; set; }

    public int? RequestId { get; set; }

    public string? ContractStatus { get; set; }

    public string? UserName { get; set; }

    public string? StuffName { get; set; }

    public int? IkzCode { get; set; }

    public DateOnly? DateRequestStart { get; set; }

    public DateOnly? DateContractStart { get; set; }

    public int? PartnerId { get; set; }

    public int? OrganisationId { get; set; }

    public DateOnly? DateContractUpdate { get; set; }

    public DateOnly? DateRequestUpdate { get; set; }

    public virtual User? Organisation { get; set; }

    public virtual User? Partner { get; set; }

    public virtual Request? Request { get; set; }
}
