using Labb1_NLP_QA_MVC.Models;
using Labb1_NLP_QA_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Labb1_NLP_QA_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuestionAnsweringService _qaService; // Referens till QA-tj�nsten

        public HomeController(QuestionAnsweringService qaService)
        {
            _qaService = qaService; // Initiera QA-tj�nsten via dependency injection
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AskQuestion(string question)
        {
            var answer = _qaService.GetAnswer(question); // Anropar tj�nsten f�r att f� svar p� fr�gan
            ViewBag.Question = question;
            ViewBag.Answer = answer;
            return View("Index");
        }
    }
}
