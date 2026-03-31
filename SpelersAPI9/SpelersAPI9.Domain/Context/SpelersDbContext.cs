using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpelersAPI9.Domain.Entities;

namespace SpelersAPI9.Domain.Context;

public partial class SpelersDbContext : DbContext
{
    public SpelersDbContext()
    {
    }

    public SpelersDbContext(DbContextOptions<SpelersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Posities> Posities { get; set; }

    public virtual DbSet<Speler> Spelers { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=VoetbalDB;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Posities>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posities__3214EC074983F527");

            entity.Property(e => e.Naam).HasMaxLength(50);
        });

        modelBuilder.Entity<Speler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spelers__3214EC072F264E43");

            entity.Property(e => e.Naam).HasMaxLength(100);

            entity.HasOne(d => d.Positie).WithMany(p => p.Spelers)
                .HasForeignKey(d => d.PositieId)
                .HasConstraintName("FK__Spelers__Positie__3C69FB99");

            entity.HasOne(d => d.Team).WithMany(p => p.Spelers)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__Spelers__TeamId__3B75D760");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teams__3214EC07BCD3F0BB");

            entity.Property(e => e.Naam).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
