using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace realestate.Controllers
{

    public class QuestionController : Controller
    {
        private readonly IQuestionRepository repo;
        public QuestionController(IQuestionRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index(int id)
        {
            var Chapter = id;


            var databaseData = repo.GetNextQuestion(Chapter, 0);
            databaseData.chapter = Chapter;
            databaseData.questions_right = 0;
            databaseData.questions_tried = 0;
            databaseData.whichScreen = "I";
            return View(databaseData);
        }
        [HttpPost]
        public ActionResult VerifyData(IFormCollection form, [FromForm] FormData p)
        {
            int Chapter = int.Parse(p.chapter);
            if (p.UserAnswer == p.CorrectAnswer)
            {
                p.questions_right++;
                p.questions_tried++;
                var databaseData = repo.GetNextQuestion(Chapter, p.question_id);
                databaseData.chapter = Chapter;
                if (databaseData.whichScreen == "F")
                {
                    databaseData.whichScreen = "F";
                    databaseData.questions_right = p.questions_right;
                    databaseData.questions_tried = p.questions_tried;
                    return View(databaseData);

                } else
                {
                    databaseData.whichScreen = "C";
                    databaseData.questions_right = p.questions_right;
                    databaseData.questions_tried = p.questions_tried;
                    return View(databaseData);
                }
            } else
            {
                p.questions_tried++;
                var databaseData = repo.GetSpecificQuestion(Chapter, p.question_id);
                databaseData.chapter = Chapter;
                databaseData.whichScreen = "W";
                databaseData.questions_right = p.questions_right;
                databaseData.questions_tried = p.questions_tried;
                return View(databaseData);
            }
        }

        public IActionResult Index1()
        {
            var databaseData = repo.GetQuestions(1);
            return View(databaseData);
        }
    }
}
