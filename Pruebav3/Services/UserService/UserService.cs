using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pruebav3.Data;
using Pruebav3.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pruebav3.Services.AuthRepository
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<bool> Existente(string name)
        {
            if (await _context.Login.AnyAsync(u => u.Name.ToLower() == name.ToLower()))
            {
                return true;
            }
            return false;
        }

        public async Task<ServiceResponse<string>> Login(string name, string password)
        {
            //var user = await _context.Login.FirstOrDefaultAsync(u => u.Name.ToLower().Equals(name.ToLower()));

            //if(VerificarPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //{
            //    CrearToken(user);
            //}


            var response = new ServiceResponse<string>();
            var user = await _context.Login.FirstOrDefaultAsync(u => u.Name.ToLower().Equals(name.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "Usuario no encontrado";
            }
            else if (!VerificarPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Contraseña erronea";
            }
            else
            {
                response.Data = CrearToken(user);
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Registro (Login name, string password)
        {
            //CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            //name.PasswordHash = passwordHash;
            //name.PasswordSalt = passwordSalt;

            //_context.Login.Add(name);
            //await _context.SaveChangesAsync();


            ServiceResponse<int> response = new ServiceResponse<int>();

            CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            name.PasswordHash = passwordHash;
            name.PasswordSalt = passwordSalt;

            _context.Login.Add(name);
            await _context.SaveChangesAsync();
            response.Data = name.IdLog;
            return response;

        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CrearToken(Login log)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, log.IdLog.ToString()),
                new Claim(ClaimTypes.Name, log.Name)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        
    }
}
