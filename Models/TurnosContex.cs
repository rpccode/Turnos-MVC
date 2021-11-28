using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options) : base(options)
        {

        }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }

        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidad");

                entidad.HasKey(e => e.IdEspecialidad);

                entidad.Property(e => e.Descripccion).IsRequired().HasMaxLength(200)
                .IsUnicode(false);
            });

            builder.Entity<Paciente>(entidad =>
            {

                entidad.ToTable("Paciente");

                entidad.HasKey(e => e.IdPaciente);

                entidad.Property(e => e.Nombre).IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Apellidos).IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Direccion).IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono).IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);


                entidad.Property(e => e.Email).IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);





            });

            builder.Entity<Medico>(entidad =>
            {
                entidad.ToTable("Medico");

                entidad.HasKey(e => e.IdMedico);

                entidad.Property(e => e.Nombre).IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

                entidad.Property(e => e.Apellidos).IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(e => e.Direccion).IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(e => e.Telefono).IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);


                entidad.Property(e => e.Email).IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entidad.Property(e => e.HorarioAtencionDesde)
                .IsRequired()
                 .IsUnicode(false);

                entidad.Property(e => e.HorarioAtencionHasta)
             .IsRequired()
              .IsUnicode(false);





            });

            builder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspecialidad });

            builder.Entity<MedicoEspecialidad>().HasOne(x => x.medico)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdMedico);

            builder.Entity<MedicoEspecialidad>().HasOne(x => x.especialidad)
        .WithMany(p => p.MedicoEspecialidad)
        .HasForeignKey(p => p.IdEspecialidad);

        }


    }
}
