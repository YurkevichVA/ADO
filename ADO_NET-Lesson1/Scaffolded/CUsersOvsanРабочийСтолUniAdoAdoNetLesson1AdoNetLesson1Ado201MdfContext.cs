using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ADO_NET_Lesson1.Scaffolded;

public partial class CUsersOvsanРабочийСтолUniAdoAdoNetLesson1AdoNetLesson1Ado201MdfContext : DbContext
{
    public CUsersOvsanРабочийСтолUniAdoAdoNetLesson1AdoNetLesson1Ado201MdfContext()
    {
    }

    public CUsersOvsanРабочийСтолUniAdoAdoNetLesson1AdoNetLesson1Ado201MdfContext(DbContextOptions<CUsersOvsanРабочийСтолUniAdoAdoNetLesson1AdoNetLesson1Ado201MdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ovsan\\Рабочий стол\\Uni\\ADO\\ADO_NET-Lesson1\\ADO_NET-Lesson1\\ADO-201.mdf\";Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07BDC72E88");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DeleteDt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Managers__3214EC07B0CA47C2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DeleteDt).HasColumnType("datetime");
            entity.Property(e => e.IdChief).HasColumnName("Id_chief");
            entity.Property(e => e.IdMainDep).HasColumnName("Id_main_dep");
            entity.Property(e => e.IdSecDep).HasColumnName("Id_sec_dep");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Secname)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.IdMainDepNavigation).WithMany(p => p.ManagerIdMainDepNavigations)
                .HasForeignKey(d => d.IdMainDep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Managers__Id_mai__4D94879B");

            entity.HasOne(d => d.IdSecDepNavigation).WithMany(p => p.ManagerIdSecDepNavigations)
                .HasForeignKey(d => d.IdSecDep)
                .HasConstraintName("FK__Managers__Id_sec__4E88ABD4");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07F45CBDFD");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DeleteDt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sales__3214EC078AAEF851");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DeleteDt).HasColumnType("datetime");
            entity.Property(e => e.ManagerId).HasColumnName("Manager_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            entity.Property(e => e.SaleDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Manager).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sales__Manager_I__5FB337D6");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sales__Product_I__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
