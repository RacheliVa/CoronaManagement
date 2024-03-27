using System;
using System.Collections.Generic;

namespace DAL;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public DateOnly? BirthDate { get; set; }

    public short? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();

    public virtual ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
}
