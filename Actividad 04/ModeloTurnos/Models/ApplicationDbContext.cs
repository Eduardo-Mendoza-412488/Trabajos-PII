using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ModeloTurnos.Models
{
    public partial class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<DetalleTurno> DetallesTurnos { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Puedes dejar esto vacío si estás configurando en Startup.cs
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleTurno>(entity =>
            {
                entity.HasKey(e => new { e.IdTurno, e.IdServicio });
                entity.ToTable("DetallesTurno");

                entity.Property(e => e.IdTurno).HasColumnName("id_turno");
                entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("Servicios");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Monto).HasColumnName("costo");
                entity.Property(e => e.Promocion)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Promocion");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.ToTable("Turnos");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cliente");
                entity.Property(e => e.Fecha)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fecha");
                entity.Property(e => e.Hora)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("hora");


                // Propiedades agregadas por nosotros
                entity.Property(e => e.Cancelacion)
                    .HasColumnName("Cancelacion");
                entity.Property(e => e.MotivoCancelacion)
                    .HasColumnName("motivo_cancelacion");
            });
            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
