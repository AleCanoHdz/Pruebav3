using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pruebav3.Models;

public partial class Categorie
{
    [Key]
    public Guid IdCategorie { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Survey> Surveys { get; } = new List<Survey>();
}
