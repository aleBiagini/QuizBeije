using System;
using System.Collections.Generic;

namespace QuizBeije.Models
{
    public partial class UsersQuiz
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int UserQuizId { get; set; }

        public virtual Quiz Quiz { get; set; }
        public virtual Users User { get; set; }
    }
}
