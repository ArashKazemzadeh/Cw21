using System;
using System.Collections.Generic;

namespace CW21.DAL.Entities;

public partial class Expertise
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
