using Microsoft.EntityFrameworkCore;
using Senai.CodeTur.Dominio.Entidades;

namespace Senai.CodeTur.Infra.Data.Contextos
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// </summary>
    public class CodeTurContext : DbContext
    {
        public DbSet <UsuarioDominio> Usuarios { get; set; }

        public DbSet<PacoteDominio> Pacotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=43765601896;Initial Catalog=CodeTurDev-Candida;User Id=sa;password=S#nai@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioDominio>().HasData(
                new UsuarioDominio() { Id = 1, Email = "admin@admin.com", Senha = "12345" });
            base.OnModelCreating(modelBuilder);
        }
    }
}

/*
Ferramentas - Gerenciador de Pacotes do NUget - Console do Gerenciador de Pacotes - Mudar nome PASTA

    Add-Migration "Cria tabela Pacotes"
    Update-Database
*/
