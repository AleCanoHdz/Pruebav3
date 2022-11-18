using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pruebav3.Models;

public partial class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string FirstSurname { get; set; } = null!;

    public string? LastSurname { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public bool Status { get; set; }

    public Guid IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<UserAnswer> UserAnswers { get; } = new List<UserAnswer>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
