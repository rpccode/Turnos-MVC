using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }
        public string Descripccion { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}