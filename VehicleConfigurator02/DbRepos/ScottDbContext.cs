using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VehicleConfigurator02.DbRepos;

public partial class ScottDbContext : DbContext
{
    public ScottDbContext()
    {
    }

    public ScottDbContext(DbContextOptions<ScottDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlternateComponent> AlternateComponents { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<FeedbackEntity> FeedbackEntities { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Segment> Segments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VehicleDetail> VehicleDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=vehicle;user id=root;password=Shu@1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlternateComponent>(entity =>
        {
            entity.HasKey(e => e.AltId).HasName("PRIMARY");

            entity.ToTable("alternate_component");

            entity.Property(e => e.AltId).HasColumnName("alt_id");
            entity.Property(e => e.AltCompId).HasColumnName("alt_comp_id");
            entity.Property(e => e.CompId).HasColumnName("comp_id");
            entity.Property(e => e.DeltaPrice).HasColumnName("delta_price");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
        });

        modelBuilder.Entity<Component>(entity =>
        {
            entity.HasKey(e => e.CompId).HasName("PRIMARY");

            entity.ToTable("component");

            entity.Property(e => e.CompId).HasColumnName("comp_id");
            entity.Property(e => e.CompName)
                .HasMaxLength(255)
                .HasColumnName("comp_name");
            entity.Property(e => e.SubType)
                .HasMaxLength(255)
                .HasColumnName("sub_type");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contact_us");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasColumnName("message");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<FeedbackEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feedback_entity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .HasColumnName("comments");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FeedbackType)
                .HasMaxLength(255)
                .HasColumnName("feedback_type");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvId).HasName("PRIMARY");

            entity.ToTable("invoice");

            entity.Property(e => e.InvId).HasColumnName("inv_id");
            entity.Property(e => e.InvDate)
                .HasColumnType("date")
                .HasColumnName("inv_date");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
        });

        modelBuilder.Entity<Manufacturer>(entity =>   //fluent api to configure mapping bw class and table
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("manufacturers");

            entity.HasIndex(e => e.SegId, "FKvt86n4h6jurg9ofnq26txaw7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ManuName)
                .HasMaxLength(255)
                .HasColumnName("manu_name");
            entity.Property(e => e.SegId).HasColumnName("seg_id");

            entity.HasOne(d => d.Seg).WithMany(p => p.Manufacturers)
                .HasForeignKey(d => d.SegId)
                .HasConstraintName("FKvt86n4h6jurg9ofnq26txaw7");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("models");

            entity.HasIndex(e => e.SegId, "FKeoehxbf066gnexos8p4o9fn5e");

            entity.HasIndex(e => e.MfgId, "FKg5yu6wt9e8520ni10gq8u6b7j");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.MfgId).HasColumnName("mfg_id");
            entity.Property(e => e.ModelName)
                .HasMaxLength(255)
                .HasColumnName("model_name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SegId).HasColumnName("seg_id");

            entity.HasOne(d => d.Mfg).WithMany(p => p.Models)
                .HasForeignKey(d => d.MfgId)
                .HasConstraintName("FKg5yu6wt9e8520ni10gq8u6b7j");

            entity.HasOne(d => d.Seg).WithMany(p => p.Models)
                .HasForeignKey(d => d.SegId)
                .HasConstraintName("FKeoehxbf066gnexos8p4o9fn5e");
        });

        modelBuilder.Entity<Segment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("segments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SegName)
                .HasMaxLength(255)
                .HasColumnName("seg_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AuthCell)
                .HasMaxLength(255)
                .HasColumnName("auth_cell");
            entity.Property(e => e.AuthTel)
                .HasMaxLength(255)
                .HasColumnName("auth_tel");
            entity.Property(e => e.CompName)
                .HasMaxLength(255)
                .HasColumnName("comp_name");
            entity.Property(e => e.CompStNo)
                .HasMaxLength(255)
                .HasColumnName("comp_st_no");
            entity.Property(e => e.Designation)
                .HasMaxLength(255)
                .HasColumnName("designation");
            entity.Property(e => e.Emailid)
                .HasMaxLength(255)
                .HasColumnName("emailid");
            entity.Property(e => e.Holding)
                .HasMaxLength(255)
                .HasColumnName("holding");
            entity.Property(e => e.NameAuthPerson)
                .HasMaxLength(255)
                .HasColumnName("name_auth_person");
            entity.Property(e => e.Pan)
                .HasMaxLength(255)
                .HasColumnName("pan");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Telephone)
                .HasMaxLength(255)
                .HasColumnName("telephone");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.VatNo)
                .HasMaxLength(255)
                .HasColumnName("vat_no");
        });

        modelBuilder.Entity<VehicleDetail>(entity =>
        {
            entity.HasKey(e => e.ConfigId).HasName("PRIMARY");

            entity.ToTable("vehicle_detail");

            entity.HasIndex(e => e.CompId, "FKa593xqt4mxktc7m7oupjoguuy");

            entity.HasIndex(e => e.ModelId, "FKaedld9hn41o0mnv18bdj2el4y");

            entity.Property(e => e.ConfigId).HasColumnName("config_id");
            entity.Property(e => e.CompId).HasColumnName("comp_id");
            entity.Property(e => e.CompType)
                .HasMaxLength(255)
                .HasColumnName("comp_type");
            entity.Property(e => e.IsConfigurable)
                .HasMaxLength(255)
                .HasColumnName("is_configurable");
            entity.Property(e => e.ModelId).HasColumnName("model_id");

            entity.HasOne(d => d.Comp).WithMany(p => p.VehicleDetails)
                .HasForeignKey(d => d.CompId)
                .HasConstraintName("FKa593xqt4mxktc7m7oupjoguuy");

            entity.HasOne(d => d.Model).WithMany(p => p.VehicleDetails)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FKaedld9hn41o0mnv18bdj2el4y");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
