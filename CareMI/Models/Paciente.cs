using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareMI.Models
{
    [Table("t_paciente")]
    public class Paciente
    {
        [Key]
        public int cdPaciente { get; set; }
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
