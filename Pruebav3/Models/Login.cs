using System.ComponentModel.DataAnnotations;

namespace Pruebav3.Models
{
    public class Login
    {
        [Key]
        public int IdLog { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
