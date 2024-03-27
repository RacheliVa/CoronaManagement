using System;
using System.Collections.Generic;

namespace DAL;

public partial class Vaccination
{
    public short Id { get; set; }

    public int? CustId { get; set; }

    public DateOnly? Date { get; set; }

    public string? Manufacturer { get; set; }

    public virtual Customer? Cust { get; set; }
}
