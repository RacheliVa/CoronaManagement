using System;
using System.Collections.Generic;

namespace DAL;

public partial class Disease
{
    public short Id { get; set; }

    public int? CustId { get; set; }

    public DateOnly? DateIn { get; set; }

    public DateOnly? DateOut { get; set; }

    public virtual Customer? Cust { get; set; }
}
