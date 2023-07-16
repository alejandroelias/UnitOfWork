using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UnitOfWork.Models
{
    public partial class PresupuestoContext : DbContext
    {


        public PresupuestoContext(DbContextOptions<PresupuestoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plantilla> Plantilla { get; set; }
        public virtual DbSet<PlantillaTipo> PlantillaTipo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HQIKEAG\\SQLEXPRESS;Database=Presupuesto;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plantilla>(entity =>
            {
                entity.Property(e => e.PlantillaId).HasColumnName("PlantillaID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlantillaTipoId).HasColumnName("PlantillaTipoID");

                entity.HasOne(d => d.PlantillaTipo)
                    .WithMany(p => p.Plantilla)
                    .HasForeignKey(d => d.PlantillaTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plantilla_PlantillaTipo");
            });

            modelBuilder.Entity<PlantillaTipo>(entity =>
            {
                entity.HasKey(e => e.PlatillaTipoId);

                entity.Property(e => e.PlatillaTipoId).HasColumnName("PlatillaTipoID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
