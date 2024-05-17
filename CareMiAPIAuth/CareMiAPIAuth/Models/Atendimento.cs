using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareMiAPIAuth.Models
{
    [Table("T_ATENDIMENTO")]
    public class Atendimento
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdAtendimento { get; set; }
        [ForeignKey("paciente")]
        public Paciente cdPaciente { get; set; }
        [Required]
        [StringLength(500)]
        public String dsDescricao { get; set; }
        [Required]
        public int qtDias { get; set; }
        [Required]
        [StringLength(100)]
        public String dsHabito { get; set; }
        [Required]
        [StringLength(10)]
        public String dsTempoSono { get; set; }
        [Required]
        [StringLength(50)]
        public String dsHereditario { get; set; }
        [Required]
        [Column(TypeName ="DATE")]
        public DateTime dtEnvio { get; set; } = DateTime.Now;
        [Required]
        public int fgAtivo { get; set; }
    }
}
