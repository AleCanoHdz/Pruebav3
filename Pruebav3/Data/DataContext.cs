using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pruebav3.Models;

namespace Pruebav3.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Pruebav3.Models.Categorie> Categorie { get; set; } = default!;

        public DbSet<Pruebav3.Models.Question> Question { get; set; }

        public DbSet<Pruebav3.Models.QuestionAnswer> QuestionAnswer { get; set; }

        public DbSet<Pruebav3.Models.Role> Role { get; set; }

        public DbSet<Pruebav3.Models.Survey> Survey { get; set; }

        public DbSet<Pruebav3.Models.User> User { get; set; }

        public DbSet<Pruebav3.Models.UserAnswer> UserAnswer { get; set; }

        public DbSet<Pruebav3.Models.UserRole> UserRole { get; set; }

        public DbSet<Pruebav3.Models.Login> Login { get; set; }
    }
}
