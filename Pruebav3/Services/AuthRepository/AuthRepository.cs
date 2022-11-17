using Pruebav3.Models;

namespace Pruebav3.Services.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        public Task<bool> Existente(string consumidor)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(string consumer, string password)
        {
            throw new NotImplementedException();
        }

        public Task<int> Registro(User consumidor, string password)
        {
            throw new NotImplementedException();
        }
    }
}
