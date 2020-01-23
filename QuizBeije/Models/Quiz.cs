using System;
using System.Collections.Generic;

namespace QuizBeije.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Questions>();
            UsersQuiz = new HashSet<UsersQuiz>();
        }

        public int QuizId { get; set; }
        public string QuizName { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<UsersQuiz> UsersQuiz { get; set; }
    }
}
