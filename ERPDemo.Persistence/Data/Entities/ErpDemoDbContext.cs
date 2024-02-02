using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERPDemo.Persistence.Data.Entities;

public partial class ErpDemoDbContext : DbContext
{

    public ErpDemoDbContext(DbContextOptions<ErpDemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Truck> Trucks { get; set; }

    public virtual DbSet<TruckStatus> TruckStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trucks__3214EC07CC3D0B4B");

            entity.HasOne(d => d.Status).WithMany(p => p.Trucks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trucks_TruckStatuses");
        });

        modelBuilder.Entity<TruckStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TruckSta__3214EC074C89C9F3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
