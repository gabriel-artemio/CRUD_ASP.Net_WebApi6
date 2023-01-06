using ASP.NET_webAPi.Data;
using ASP.NET_webAPi.Models;
using ASP.NET_webAPi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_webAPi.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly TarefasDbContext _dbContext;
        public UsuarioRepositorio(TarefasDbContext tarefasDbContext)
        {
            _dbContext = tarefasDbContext;
        }
        public async Task<Usuario> GetById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario> Insert(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario> Update(Usuario usuario, int id)
        {
            Usuario user = await GetById(id);

            if (user == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado na base de dados.");
            }

            user.Nome = usuario.Nome;
            user.Email = usuario.Email;

            _dbContext.Usuarios.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<bool> Delete(int id)
        {
            Usuario user = await GetById(id);

            if (user == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado na base de dados.");
            }

            _dbContext.Usuarios.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}