using Pruebav3.Models;

namespace Pruebav3.Services.AuthRepository
{
    public interface IAuthRepository
    {
        Task<int> Registro(User consumidor, string password);
        Task<string> Login(string consumer, string password);
        Task<bool> Existente(string consumidor);
    }
}
