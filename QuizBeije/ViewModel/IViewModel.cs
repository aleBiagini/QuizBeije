using QuizBeije.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizBeije.ViewModel
{
    public interface IViewModel
    {
        public static readonly QuizBeijeContext context = new QuizBeijeContext();

    }
}
