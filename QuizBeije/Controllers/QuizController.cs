using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizBeije.ViewModel.Quiz;

namespace QuizBeije.Controllers
{
    public class QuizController : Controller
    {
        [Route("Quiz")]
        public IActionResult Index()
        {
            var list = QuizViewModel.GetQuizList();

            return View(list);
        }

        [Route("Quiz/{id:int}")]
        public IActionResult Detail(int id)
        {
            var quiz = QuizViewModel.GetQuizDetail(id);
            return View(quiz);
        }

        public IActionResult SendQuiz()
        {
            return View("EsamePassato");
        }


    }
}