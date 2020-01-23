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
        public IActionResult Index()
        {
            var list = QuizViewModel.GetQuizList();
            
            return View(list);
        }

        
    }
}