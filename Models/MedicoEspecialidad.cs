namespace Turnos.Models
{
    public class MedicoEspecialidad
    {
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }

        public Medico medico { get; set; }

        public Especialidad especialidad { get; set; }


    }
}