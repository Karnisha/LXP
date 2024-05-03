using System;
using System.Collections.Generic;
using LXP.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LXP.Data.DBContexts;

public partial class LXPDbContext : DbContext
{
    public LXPDbContext()
    {
    }

    public LXPDbContext(DbContextOptions<LXPDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Coursecategory> Coursecategories { get; set; }

    public virtual DbSet<Courselevel> Courselevels { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Materialtype> Materialtypes { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Userprogress> Userprogresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=capstoneproject;uid=root;pwd=Password@12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("course");

            entity.HasIndex(e => e.CatagoryId, "IX_Course_CatagoryID");

            entity.HasIndex(e => e.LevelId, "IX_Course_LevelID");

            entity.Property(e => e.CourseId)
                .HasColumnName("CourseID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CatagoryId)
                .HasColumnName("CatagoryID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(120);
            entity.Property(e => e.LevelId)
                .HasColumnName("LevelID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(120);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Catagory).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CatagoryId)
                .HasConstraintName("FK_Course_CourseCategory_CatagoryID");

            entity.HasOne(d => d.Level).WithMany(p => p.Courses)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK_Course_CourseLevels_LevelID");
        });

        modelBuilder.Entity<Coursecategory>(entity =>
        {
            entity.HasKey(e => e.CatagoryId).HasName("PRIMARY");

            entity.ToTable("coursecategory");

            entity.Property(e => e.CatagoryId)
                .HasColumnName("CatagoryID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(120);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(120);
        });

        modelBuilder.Entity<Courselevel>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PRIMARY");

            entity.ToTable("courselevels");

            entity.Property(e => e.LevelId)
                .HasColumnName("LevelID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(120);
            entity.Property(e => e.Level).HasMaxLength(50);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(120);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PRIMARY");

            entity.ToTable("materials");

            entity.HasIndex(e => e.MaterialTypeId, "IX_Materials_MaterialTypeId");

            entity.HasIndex(e => e.TopicId, "IX_Materials_TopicID");

            entity.Property(e => e.MaterialId)
                .HasColumnName("MaterialID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(120);
            entity.Property(e => e.MaterialTypeId)
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(120);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TopicId)
                .HasColumnName("TopicID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialTypeId)
                .HasConstraintName("FK_Materials_MaterialTypes_MaterialTypeId");

            entity.HasOne(d => d.Topic).WithMany(p => p.Materials)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_Materials_Topic_TopicID");
        });

        modelBuilder.Entity<Materialtype>(entity =>
        {
            entity.HasKey(e => e.MaterialTypeId).HasName("PRIMARY");

            entity.ToTable("materialtypes");

            entity.Property(e => e.MaterialTypeId)
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PRIMARY");

            entity.ToTable("topic");

            entity.HasIndex(e => e.CourseId, "IX_Topic_CourseID");

            entity.Property(e => e.TopicId)
                .HasColumnName("TopicID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CourseId)
                .HasColumnName("CourseID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(120);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(120);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Course).WithMany(p => p.Topics)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Topic_Course_CourseID");
        });

        modelBuilder.Entity<Userprogress>(entity =>
        {
            entity.HasKey(e => e.UserProgressId).HasName("PRIMARY");

            entity.ToTable("userprogress");

            entity.HasIndex(e => e.CourseId, "IX_UserProgress_CourseID");

            entity.HasIndex(e => e.MaterialId, "IX_UserProgress_MaterialID");

            entity.HasIndex(e => e.TopicId, "IX_UserProgress_TopicID");

            entity.Property(e => e.UserProgressId)
                .HasColumnName("UserProgressID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.CourseId)
                .HasColumnName("CourseID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.MaterialId)
                .HasColumnName("MaterialID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.TopicId)
                .HasColumnName("TopicID")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.TotalTime).HasColumnType("time");
            entity.Property(e => e.UserId)
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
            entity.Property(e => e.WatchTime).HasColumnType("time");

            entity.HasOne(d => d.Course).WithMany(p => p.Userprogresses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_UserProgress_Course_CourseID");

            entity.HasOne(d => d.Material).WithMany(p => p.Userprogresses)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_UserProgress_Materials_MaterialID");

            entity.HasOne(d => d.Topic).WithMany(p => p.Userprogresses)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK_UserProgress_Topic_TopicID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
