using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pruebav3.Models;

public partial class UserRole
{
    [Key]
    public Guid IdUserRole { get; set; }

    public Guid IdUser { get; set; }

    public Guid IdRole { get; set; }

    public bool Status { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
