using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareMiAPIAuth.Models
{
    [Table("t_atendimento")]
    public class Atendimento
    {

        [Key]
        public int cdAtendimento { get; set; }
        [Required]
        public String dsDescricao { get; set; }
        [Required]
        public int qtDias { get; set; }
        [Required]
        public String dsHabito { get; set; }
        [Required]
        public String dsTempoSono { get; set; }
        [Required]
        public String dsHereditario { get; set; }
        [Required]
        public DateOnly dtEnvio { get; set; }
        [Required]
        public int fgAtivo { get; set; }
    }
}
