using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pruebav3.Models;

public partial class Survey
{
    [Key]
    public int IdSurvey { get; set; }

    public string Name { get; set; } = null!;

    public DateTime RegisterDate { get; set; }

    public bool Status { get; set; }

    public Guid IdCategorie { get; set; }

    public virtual Categorie IdCategorieNavigation { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
