using Microsoft.EntityFrameworkCore;
using QuizBeije.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizBeije.ViewModel.Quiz
{
    public class QuizViewModel
    {
        private static readonly QuizBeijeContext context = new QuizBeijeContext();

        // ritorna la lista completa di tutti quiz
        public static IEnumerable<Models.Quiz> GetQuizList()
        {
            var query = GetQuizListAsync();
            return query.Result;
        }

        public static async Task<IEnumerable<Models.Quiz>> GetQuizListAsync()
        {
            return await context.Quiz.ToListAsync();
        }
    }
}
