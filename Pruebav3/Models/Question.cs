using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pruebav3.Models;

public partial class Question
{
    [Key]
    public Guid IdQuestion { get; set; }

    public string QuestionType { get; set; } = null!;

    public int IdSurvey { get; set; }

    public virtual Survey IdSurveyNavigation { get; set; } = null!;

    public virtual ICollection<QuestionAnswer> QuestionAnswers { get; } = new List<QuestionAnswer>();

    public virtual ICollection<UserAnswer> UserAnswers { get; } = new List<UserAnswer>();
}
