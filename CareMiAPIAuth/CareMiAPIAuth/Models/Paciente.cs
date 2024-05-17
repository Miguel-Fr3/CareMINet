using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareMiAPIAuth.Models
{
    [Table("T_PACIENTE")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdPaciente { get; set; }
        [ForeignKey("usuario")]
        public Usuario cdUsuario { get; set; }
        [Required]
        [StringLength(100)]
        public string nmPaciente { get; set; }
        [Required]
        public int nrPeso { get; set; }
        [Required]
        public int nrAltura { get; set; }
        [Required]
        [StringLength(6)]
        public string nmGrupoSanguineo { get; set; }
        [Required]
        public string flSexoBiologico { get; set; }
    }
}
