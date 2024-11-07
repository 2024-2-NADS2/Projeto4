using Microsoft.EntityFrameworkCore;
using ProjetoPI.Enum;
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

        // DbSets específicos para Produto e subclasses
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Roupa> Roupas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Calcado> Calcados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario);

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Doador>()
                .ToTable("Doadores");

            modelBuilder.Entity<Ong>()
                .ToTable("Ongs");

            modelBuilder.Entity<Doador>()
                .Property(d => d.Cpf)
                .IsRequired()
                .HasMaxLength(14);

            modelBuilder.Entity<Doador>()
                .Property(d => d.DataNascimento)
                .IsRequired();

            modelBuilder.Entity<Doador>()
                .Property(d => d.DataCadastro)
                .IsRequired();

            modelBuilder.Entity<Ong>()
                .Property(o => o.Cnpj)
                .IsRequired()
                .HasMaxLength(18);

            modelBuilder.Entity<Ong>()
                .Property(o => o.DataCadastro)
                .IsRequired();

            // Configuração separada para cada subclasse de Produto
            modelBuilder.Entity<Roupa>().ToTable("Roupas");
            modelBuilder.Entity<Livro>().ToTable("Livros");
            modelBuilder.Entity<Calcado>().ToTable("Calcados");

        }
    }
}
