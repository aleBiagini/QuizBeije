using System;
using System.Collections.Generic;

namespace QuizBeije.Models
{
    public partial class Answers
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int? QuestionId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual Questions Question { get; set; }
        public virtual Users User { get; set; }
    }
}
