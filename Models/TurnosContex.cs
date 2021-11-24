using Microsoft.EntityFrameworkCore;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> options) : base(options)
        {

        }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Especialidad>(Entidad =>
            {
                Entidad.ToTable("Especialidad");

                Entidad.HasKey(e => e.IdEspecialidad);

                Entidad.Property(e => e.Descripccion).IsRequired().HasMaxLength(200)
                .IsUnicode(false);
            });
        }
    }
}
