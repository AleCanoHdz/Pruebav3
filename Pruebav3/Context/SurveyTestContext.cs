using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pruebav3.Models;

namespace Pruebav3.Context;

public partial class SurveyTestContext : DbContext
{
    public SurveyTestContext()
    {
    }

    public SurveyTestContext(DbContextOptions<SurveyTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAnswer> UserAnswers { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CANOPC\\SQLEXPRESS;Initial Catalog=SurveyTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PK_Categories");

            entity.ToTable("Categorie");

            entity.Property(e => e.IdCategorie).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.IdQuestion).HasName("PK_Questions");

            entity.ToTable("Question");

            entity.Property(e => e.IdQuestion).ValueGeneratedNever();
            entity.Property(e => e.QuestionType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSurveyNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.IdSurvey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Surveys");
        });

        modelBuilder.Entity<QuestionAnswer>(entity =>
        {
            entity.HasKey(e => e.IdQuestionAnswer);

            entity.ToTable("QuestionAnswer");

            entity.Property(e => e.IdQuestionAnswer).ValueGeneratedNever();
            entity.Property(e => e.Answer).IsUnicode(false);

            entity.HasOne(d => d.IdQuestionNavigation).WithMany(p => p.QuestionAnswers)
                .HasForeignKey(d => d.IdQuestion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuestionAnswer_Questions");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK_Roles");

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.IdSurvey).HasName("PK_Surveys");

            entity.ToTable("Survey");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegisterDate).HasColumnType("date");

            entity.HasOne(d => d.IdCategorieNavigation).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.IdCategorie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Surveys_Categories");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK_Users");

            entity.ToTable("User");

            entity.Property(e => e.IdUser).ValueGeneratedNever();
            entity.Property(e => e.FirstSurname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastSurname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<UserAnswer>(entity =>
        {
            entity.HasKey(e => e.IdUserAnswer);

            entity.ToTable("UserAnswer");

            entity.Property(e => e.IdUserAnswer).ValueGeneratedNever();

            entity.HasOne(d => d.IdQuestionNavigation).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.IdQuestion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAnswer_Questions");

            entity.HasOne(d => d.IdQuestionAnswerNavigation).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.IdQuestionAnswer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAnswer_QuestionAnswer");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAnswer_Users");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.IdUserRole).HasName("PK_UserRoles");

            entity.ToTable("UserRole");

            entity.Property(e => e.IdUserRole).ValueGeneratedNever();

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
