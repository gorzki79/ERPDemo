using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERPDemo.Persistence.Data.Entities;

public partial class Truck
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int StatusId { get; set; }

    [StringLength(4000)]
    public string? Description { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("Trucks")]
    public virtual TruckStatus Status { get; set; } = null!;
}
