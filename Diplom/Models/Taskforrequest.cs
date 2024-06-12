using System;
using System.Collections.Generic;

namespace Diplom.Models;

public partial class Taskforrequest
{
    public int TaskCode { get; set; }

    public int? OrganizationCode { get; set; }

    public int? RequestId { get; set; }

    public DateOnly? DateOfReceipt { get; set; }

    public string? TaskStatus { get; set; }

    public string? TaskDeadline { get; set; }

    public int? IdPartner { get; set; }

    public virtual User? IdPartnerNavigation { get; set; }

    public virtual Request? Request { get; set; }
}
