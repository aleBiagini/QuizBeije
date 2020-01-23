using System;
using System.Collections.Generic;

namespace QuizBeije.Models
{
    public partial class Attempts
    {
        public int AttemptId { get; set; }
        public int UserId { get; set; }
        public bool? IsSuccess { get; set; }
        public bool? IsValid { get; set; }
        public DateTime? Timestamp { get; set; }

        public virtual Users User { get; set; }
    }
}
