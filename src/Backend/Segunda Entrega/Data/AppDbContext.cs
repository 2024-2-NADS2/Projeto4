using Microsoft.EntityFrameworkCore;
using ProjetoPI.Model;
using System.Collections.Generic;

namespace ProjetoPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }  // Tabela de Usuários
    }

}
