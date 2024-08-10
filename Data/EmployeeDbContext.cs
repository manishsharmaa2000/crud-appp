using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crud_app.Models;

namespace crud_app.Data;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-9HHUKKJ\\SQLEXPRESS; database=EmployeeDB; trusted_connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__262359ABB5A36615");

            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Emp_Desc");
            entity.Property(e => e.EmpName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Emp_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
