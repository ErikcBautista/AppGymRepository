using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppGym.Models
{
    public partial class GymDatabaseContext : DbContext
    {
        public GymDatabaseContext()
        {
        }

        public GymDatabaseContext(DbContextOptions<GymDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacoras> Bitacoras { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Jornadas> Jornadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-GKG9MVL;Initial Catalog=GymDatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bitacoras>(entity =>
            {
                entity.HasKey(e => e.IdBitacora)
                    .HasName("PK__bitacora__7E4268B006508251");

                entity.ToTable("bitacoras");

                entity.Property(e => e.IdBitacora).HasColumnName("id_bitacora");

                entity.Property(e => e.Asistencia)
                    .HasColumnName("asistencia")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEmpleadoBitacora).HasColumnName("id_empleado_bitacora");

                entity.HasOne(d => d.IdEmpleadoBitacoraNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdEmpleadoBitacora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bitacoras__id_em__2A4B4B5E");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__empleado__88B5139447610225");

                entity.ToTable("empleados");

                entity.HasIndex(e => e.NombreSesionEmpleado)
                    .HasName("UQ__empleado__04B11C5AF6489286")
                    .IsUnique();

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.ApellidosEmpleado)
                    .IsRequired()
                    .HasColumnName("apellidos_empleado")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdJornadaEmpleado).HasColumnName("id_jornada_empleado");

                entity.Property(e => e.NombreSesionEmpleado)
                    .IsRequired()
                    .HasColumnName("nombre_sesion_empleado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NombresEmpleado)
                    .IsRequired()
                    .HasColumnName("nombres_empleado")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordEmpleado)
                    .IsRequired()
                    .HasColumnName("password_empleado")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEmpleado)
                    .IsRequired()
                    .HasColumnName("telefono_empleado")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdJornadaEmpleadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdJornadaEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleados__id_jo__276EDEB3");
            });

            modelBuilder.Entity<Jornadas>(entity =>
            {
                entity.HasKey(e => e.IdJornada)
                    .HasName("PK__jornadas__6BD46D1AB877DE04");

                entity.ToTable("jornadas");

                entity.Property(e => e.IdJornada).HasColumnName("id_jornada");

                entity.Property(e => e.DiasJornada).HasColumnName("dias_jornada");

                entity.Property(e => e.NombreDias)
                    .IsRequired()
                    .HasColumnName("nombre_dias")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.NombreJornada)
                    .IsRequired()
                    .HasColumnName("nombre_jornada")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
