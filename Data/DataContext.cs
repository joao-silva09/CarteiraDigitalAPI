    using Microsoft.EntityFrameworkCore;
namespace CarteiraDigitalAPI.Data

    {
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

            }

            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<Conta> Contas { get; set; }
            public DbSet<Divida> Dividas { get; set; }
            public DbSet<Objetivo> Objetivos { get; set; }
            public DbSet<Operacao> Operacoes { get; set; }
            public DbSet<Orcamento> Orcamentos { get; set; }
            public DbSet<Planejamento> Planejamentos { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }
        }
    }

