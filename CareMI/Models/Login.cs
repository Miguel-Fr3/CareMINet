using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareMI.Models
{
    [Table("t_login")]
    public class Login
    {
        [Key]
        public int cdLogin { get; set; }
        [Required]
        public Usuario cdUsuario { get; set; }
        [Required]
        public string nrCpf { get; set; }
        [Required]
        public string dsSenha { get; set; }
        [Required]
        public int fgAtivo { get; set; }
    }

}
