using System;
using System.Collections.Generic;

namespace ADO_NET_Lesson1.Scaffolded;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public DateTime? DeleteDt { get; set; }

    public virtual ICollection<Sale> Sales { get; } = new List<Sale>();
}
