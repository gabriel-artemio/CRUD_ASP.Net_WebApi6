using ASP.NET_webAPi.Models;

namespace ASP.NET_webAPi.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>>GetUsuarios();
        Task<Usuario>GetById(int id);
        Task<Usuario>Insert(Usuario usuario);
        Task<Usuario>Update(Usuario usuario, int id);
        Task<bool>Delete(int usuario);
    }
}
