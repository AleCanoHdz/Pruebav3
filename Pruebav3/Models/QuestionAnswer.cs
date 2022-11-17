using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pruebav3.Models;

public partial class QuestionAnswer
{
    [Key]
    public Guid IdQuestionAnswer { get; set; }

    public string Answer { get; set; } = null!;

    public bool Correct { get; set; }

    public bool Status { get; set; }

    public Guid IdQuestion { get; set; }

    public virtual Question IdQuestionNavigation { get; set; } = null!;

    public virtual ICollection<UserAnswer> UserAnswers { get; } = new List<UserAnswer>();
}
