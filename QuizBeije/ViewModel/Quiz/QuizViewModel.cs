using Microsoft.EntityFrameworkCore;
using QuizBeije.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizBeije.ViewModel.Quiz
{
    public class QuizViewModel : IViewModel
    {
        // ritorna la lista completa di tutti quiz
        public static IEnumerable<Models.Quiz> GetQuizList()
        {
            var query = GetQuizListAsync();
            return query.Result;
        }
        public static async Task<IEnumerable<Models.Quiz>> GetQuizListAsync()
        {
            return await IViewModel.context.Quiz.ToListAsync();
        }

        //ritorna il dettaglio contenente un singolo quiz
        public static Models.Quiz GetQuizDetail(int id)
        {
            var query = GetQuizDetailAsync(id);
            return query.Result;
        }
        public static async Task<Models.Quiz> GetQuizDetailAsync(int id)
        {
            var quiz = IViewModel.context.Quiz.Where(x => x.QuizId == id).FirstOrDefaultAsync();
            quiz.Result.Questions = QuestionChoiceViewModel.GetQuestionChoices(id);
            return await quiz;
        }
    }

}
