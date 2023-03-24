using System;
using System.Collections.Generic;

namespace ADO_NET_Lesson1.Scaffolded;

public partial class Department
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? DeleteDt { get; set; }

    public virtual ICollection<Manager> ManagerIdMainDepNavigations { get; } = new List<Manager>();

    public virtual ICollection<Manager> ManagerIdSecDepNavigations { get; } = new List<Manager>();
}
