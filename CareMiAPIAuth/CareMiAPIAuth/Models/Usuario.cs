using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareMiAPIAuth.Models
{
    [Table("t_usuario")]
    public class Usuario
    {
        [Key]
        public int cdUsuario { get; set; }
        [Required]
        public String nmUsuario { get; set; }
        [Required]
        public DateOnly dtNascimento { get; set; }
        [Required]
        public String nrCpf { get; set; }
        [Required]
        public String nrRg { get; set; }
        [Required]
        public String dsNacionalidade { get; set; }
        [Required]
        public String nrTelefone { get; set; }
        [Required]
        public DateOnly dtCadastro { get; set; }
        [Required]
        public String dsEstadoCivil { get; set; }
        [Required]
        public String dsProfissao { get; set; }
        [Required]
        public int fgAtivo { get; set; }
    }
}
