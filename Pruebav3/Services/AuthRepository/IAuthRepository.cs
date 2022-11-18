using Pruebav3.Models;

namespace Pruebav3.Services.AuthRepository
{
    public interface IAuthRepository
    {
        Task<int> Registro(User name, string password);
        Task<string> Login(string name, string password);
        Task<bool> Existente(string name);
    }
}
