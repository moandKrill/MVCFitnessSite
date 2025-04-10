using System;
using System.Collections.Generic;
using DB_Migration_tool.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DB_Migration_tool.Data;

public partial class FitnessClubContext : DbContext
{
    public FitnessClubContext()
    {
    }

    public FitnessClubContext(DbContextOptions<FitnessClubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryTrainer> CategoryTrainers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<TrainersClub> TrainersClubs { get; set; }

    public virtual DbSet<Training> Training { get; set; }

    public virtual DbSet<TrainingLevel> TrainingLevels { get; set; }

    public virtual DbSet<TrainingType> TrainingTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=31.31.196.28;database=u2793557_FitnessClub;user id=u2793557_fitness;password=nP6uM5oE7psZ2oF8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.44-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CategoryTrainer>(entity =>
        {
            entity.HasKey(e => e.IdCategoryTrainer).HasName("PRIMARY");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PRIMARY");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.IdTrainer).HasName("PRIMARY");
        });

        modelBuilder.Entity<TrainersClub>(entity =>
        {
            entity.HasKey(e => e.IdTrainersClub).HasName("PRIMARY");

            entity.HasOne(d => d.IdCategoryTrainerNavigation).WithMany(p => p.TrainersClubs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trainers_club_ibfk_2");

            entity.HasOne(d => d.IdTrainersNavigation).WithMany(p => p.TrainersClubs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trainers_club_ibfk_1");

            entity.HasOne(d => d.IdTrainingTypeNavigation).WithMany(p => p.TrainersClubs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trainers_club_ibfk_3");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.IdTraining).HasName("PRIMARY");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Training).HasConstraintName("fk_client");

            entity.HasOne(d => d.IdLevelNavigation).WithMany(p => p.Training)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("training_ibfk_1");

            entity.HasOne(d => d.IdTrainersClubNavigation).WithMany(p => p.Training)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("training_ibfk_2");
        });

        modelBuilder.Entity<TrainingLevel>(entity =>
        {
            entity.HasKey(e => e.IdLevel).HasName("PRIMARY");
        });

        modelBuilder.Entity<TrainingType>(entity =>
        {
            entity.HasKey(e => e.IdTrainingType).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
