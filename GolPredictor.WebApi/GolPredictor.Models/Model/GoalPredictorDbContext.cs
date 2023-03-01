using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GolPredictor.Models.Model
{
    public partial class GoalPredictorDbContext : DbContext
    {
        public GoalPredictorDbContext()
        {
        }

        public GoalPredictorDbContext(DbContextOptions<GoalPredictorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Sesion> Sesion { get; set; }
        public virtual DbSet<SesionUsuario> SesionUsuario { get; set; }
        public virtual DbSet<UserAdmin> UserAdmin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=JUANJE-PC;Database=GoalPredictorDb; User Id=sa; Password=juanje9225;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.Property(e => e.Abreviatura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.ResultTeam1).HasDefaultValueSql("((0))");

                entity.Property(e => e.ResultTeam2).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Team1)
                    .WithMany(p => p.PartidoTeam1)
                    .HasForeignKey(d => d.Team1Id)
                    .HasConstraintName("FK_Partido_Pais_Team1");

                entity.HasOne(d => d.Team2)
                    .WithMany(p => p.PartidoTeam2)
                    .HasForeignKey(d => d.Team2Id)
                    .HasConstraintName("FK_Partido_Pais_Team2");
            });

            modelBuilder.Entity<Sesion>(entity =>
            {
                entity.Property(e => e.EntryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Partido)
                    .WithMany(p => p.Sesion)
                    .HasForeignKey(d => d.PartidoId)
                    .HasConstraintName("FK_Sesion_Partido");
            });

            modelBuilder.Entity<SesionUsuario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSesionNavigation)
                    .WithMany(p => p.SesionUsuario)
                    .HasForeignKey(d => d.IdSesion)
                    .HasConstraintName("FK_SesionUsuario_Sesion");
            });

            modelBuilder.Entity<UserAdmin>(entity =>
            {
                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
