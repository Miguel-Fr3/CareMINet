using CareMI.Models;
using Microsoft.EntityFrameworkCore;

namespace CareMI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Atendimento> atendimentos { get; set; }
        public DbSet<Login> logins { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
    }
}
