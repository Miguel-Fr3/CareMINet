using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareMiAPIAuth.Models
{
    [Table("T_USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdUsuario { get; set; }
        [Required]
        [StringLength(20)]
        public String nmUsuario { get; set; }
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtNascimento { get; set; }
        [Required]
        [StringLength(15)]
        public String nrCpf { get; set; }
        [Required]
        [StringLength(15)]
        public String nrRg { get; set; }
        [Required]
        [StringLength(50)]
        public String dsNacionalidade { get; set; }
        [Required]
        [StringLength(15)]
        public String nrTelefone { get; set; }
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime dtCadastro { get; set; } = DateTime.Now;
        [StringLength(100)]
        public String dsEstadoCivil { get; set; }
        [StringLength(100)]
        public String dsProfissao { get; set; }
        [Required]
        public int fgAtivo { get; set; }
    }
}
