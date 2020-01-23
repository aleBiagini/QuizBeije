using System;
using System.Collections.Generic;

namespace QuizBeije.Models
{
    public partial class Users
    {
        public Users()
        {
            Answers = new HashSet<Answers>();
            Attempts = new HashSet<Attempts>();
            UsersQuiz = new HashSet<UsersQuiz>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string ProfilImage { get; set; }

        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<Attempts> Attempts { get; set; }
        public virtual ICollection<UsersQuiz> UsersQuiz { get; set; }
    }
}
