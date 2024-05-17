using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareMiAPIAuth.Models
{
    [Table("t_paciente")]
    public class Paciente
    {
        [Key]
        public int cdPaciente { get; set; }
        public Atendimento cdAtendimento { get; set; }
        [Required]
        public string nmPaciente { get; set; }
        [Required]
        public int nrPeso { get; set; }
        [Required]
        public int nrAltura { get; set; }
        [Required]
        public string nmGrupoSanguineo { get; set; }
        [Required]
        public string flSexoBiologico { get; set; }
    }
}
