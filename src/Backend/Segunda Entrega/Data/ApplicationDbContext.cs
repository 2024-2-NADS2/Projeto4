using Microsoft.EntityFrameworkCore;
using ProjetoPI.Model;

namespace ProjetoPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ong> Ongs { get; set; }
        public DbSet<Doador> Doadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para a entidade Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario); // Define a chave primária

            modelBuilder.Entity<Usuario>()
        .ToTable("Usuarios"); // Define o nome da tabela

            modelBuilder.Entity<Doador>()
                .ToTable("Doadores");

            modelBuilder.Entity<Ong>()
                .ToTable("Ongs");
            // Configuração para a entidade Doador
            modelBuilder.Entity<Doador>()
                .Property(d => d.Cpf)
                .IsRequired()
                .HasMaxLength(14); // Configuração adicional para CPF

            modelBuilder.Entity<Doador>()
                .Property(d => d.DataNascimento)
                .IsRequired(); // Data de nascimento obrigatória

            modelBuilder.Entity<Doador>()
                .Property(d => d.DataCadastro)
                .IsRequired(); // Data de cadastro obrigatória

            // Configuração para a entidade Ong
            modelBuilder.Entity<Ong>()
                .Property(o => o.Cnpj)
                .IsRequired()
                .HasMaxLength(18); // CNPJ obrigatório com limite de 18 caracteres

            modelBuilder.Entity<Ong>()
                .Property(o => o.DataCadastro)
                .IsRequired(); // Data de cadastro obrigatória
        }
    }
}
