using Microsoft.AspNetCore.Mvc;

namespace realestate.Controllers
{
    public class NewquestionController : Controller
    {
        private readonly INewquestionRepository repo;
        public NewquestionController(INewquestionRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Question formData)
        {
            var newQuestion = new Question();
            newQuestion.chapter = formData.chapter;
            newQuestion.question = formData.question;
            newQuestion.answer_1 = formData.answer_1;
            newQuestion.answer_2 = formData.answer_2;
            newQuestion.answer_3 = formData.answer_3;
            newQuestion.answer_4 = formData.answer_4;
            newQuestion.correct_answer = formData.correct_answer;
            repo.SaveQuestions(newQuestion);
            ModelState.Clear();
            return View();
        }
    }
}
