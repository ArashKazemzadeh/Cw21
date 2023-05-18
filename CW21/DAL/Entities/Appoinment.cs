using System;
using System.Collections.Generic;

namespace CW21.DAL.Entities;

public partial class Appoinment
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int DoctorId { get; set; }

    public int? PatientId { get; set; }

    public string? Description { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient? Patient { get; set; }
}
