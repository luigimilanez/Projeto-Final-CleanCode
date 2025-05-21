using clean_code_refactor.Business.Models.Clientes;
using clean_code_refactor.Business.Models.Reservas;
using Microsoft.EntityFrameworkCore;

namespace clean_code_refactor.Dal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
