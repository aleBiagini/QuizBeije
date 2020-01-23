using Microsoft.EntityFrameworkCore;
using QuizBeije.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizBeije.ViewModel
{
    public class QuestionChoiceViewModel
    {
        //public Questions Question { get; set; }
        //public IList<Choices> Choices { get; set; }
        //ritorna le domande e le risposte possibili associate ad un quiz
        public static ICollection<Models.Questions> GetQuestionChoices(int id)
        {
            var questions = IViewModel.context.Questions.Where(x => x.QuizId == id);

            return questions.Include(x => x.Choices).ToList();



        }
    }
}
