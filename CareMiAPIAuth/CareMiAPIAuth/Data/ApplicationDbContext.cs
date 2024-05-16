using CareMiAPIAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace CareMiAPIAuth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
