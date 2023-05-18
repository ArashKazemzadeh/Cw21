using System;
using System.Collections.Generic;

namespace CW21.DAL.Entities;

public partial class Patient
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Appoinment> Appoinments { get; set; } = new List<Appoinment>();
}
