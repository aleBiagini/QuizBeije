using System;
using System.Collections.Generic;

namespace QuizBeije.Models
{
    public partial class Choices
    {
        public int ChoiceId { get; set; }
        public string ChoiceText { get; set; }
        public int? QuestionId { get; set; }
        public bool? IsCorrect { get; set; }

        public virtual Questions Question { get; set; }
    }
}
