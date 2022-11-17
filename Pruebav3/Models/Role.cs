using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pruebav3.Models;

public partial class Role
{
    [Key]
    public Guid IdRole { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
