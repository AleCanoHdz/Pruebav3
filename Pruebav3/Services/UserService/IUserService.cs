using Pruebav3.Models;

namespace JWT.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> Registro(Login Name, string password);
        Task<ServiceResponse<string>> Login(string Name, string password);
        Task<bool> Existente(string consumidor);
    }
}
