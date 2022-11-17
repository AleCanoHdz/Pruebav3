using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pruebav3.Models;

public partial class UserAnswer
{
    [Key]
    public Guid IdUserAnswer { get; set; }

    public Guid IdUser { get; set; }

    public Guid IdQuestion { get; set; }

    public Guid IdQuestionAnswer { get; set; }

    public virtual QuestionAnswer IdQuestionAnswerNavigation { get; set; } = null!;

    public virtual Question IdQuestionNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
