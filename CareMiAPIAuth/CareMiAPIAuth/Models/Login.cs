using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareMiAPIAuth.Models
{
    [Table("T_LOGIN")]
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cdLogin { get; set; }

        [Required]
        [StringLength(15)]
        public string nrCpf { get; set; }
        [Required]
        [StringLength(100)]
        public string dsSenha { get; set; }
        [Required]
        public int fgAtivo { get; set; }
    }

}
