using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareMI.Models
{
    [Table("t_usuario")]
    public class Usuario
    {
        [Key]
        public int cdUsuario { get; set; }
        public String nmUsuario { get; set; }
        public DateOnly dtNascimento { get; set; }
        public String nrCpf { get; set; }
        public String nrRg { get; set; }
        public String dsNacionalidade { get; set;}
        public String nrTelefone { get; set; }
        public DateOnly dtCadastro { get; set; }
        public String dsEstadoCivil { get;set; }
        public String dsProfissao { get; set; }
        public int fgAtivo { get; set; }
    }
}
