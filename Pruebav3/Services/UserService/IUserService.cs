using Pruebav3.Models;

namespace JWT.Services.UserService
{
    public interface IUserService
    {
        Task Registro(User Name, string password);
        Task Login(string Name, string password);
        Task<bool> Existente(string consumidor);
    }
}
