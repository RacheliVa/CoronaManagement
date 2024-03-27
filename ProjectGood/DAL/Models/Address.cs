using System;
using System.Collections.Generic;

namespace DAL;

public partial class Address
{
    public short Id { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? NumHouse { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
