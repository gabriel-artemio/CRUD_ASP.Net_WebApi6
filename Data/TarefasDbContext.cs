using ASP.NET_webAPi.Data.Map;
using ASP.NET_webAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_webAPi.Data
{
    public class TarefasDbContext : DbContext
    {
        public TarefasDbContext(DbContextOptions<TarefasDbContext> options)
            :base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}