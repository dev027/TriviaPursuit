using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tp.Website.Models.QuestionBank;

namespace Tp.Website.Controllers
{
    public partial class QuestionBankController : Controller
    {
        private Service.Service Service { get; }

        public QuestionBankController()
        {
            Service = new Service.Service();
        }

        public virtual IActionResult Index()
        {
            var questionBankSummaries = Service.Category.GetQuestionBankSummaries();
            var model = IndexViewModel.Create(questionBankSummaries);
            return View(model);
        }

        [HttpGet]
        public virtual IActionResult Add(int categoryId)
        {
            var category = Service.Category.GetById(categoryId);
            var model = AddViewModel.Create(category);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Add(AddQuestionPostModel inModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Service.Question.Create(
                inModel.CategoryId,
                inModel.Question,
                inModel.CorrectAnswer,
                inModel.WrongAnswer1,
                inModel.WrongAnswer2,
                inModel.WrongAnswer3,
                inModel.AllNone);

            var category = Service.Category.GetById(inModel.CategoryId);

            var outModel = AddQuestionViewModel.Create(category, inModel);
            return PartialView(MVC.QuestionBank.Views._AddQuestion, outModel);
        }

        public class AddQuestionPostModel
        {
            public int CategoryId { get; set; }

            [Required(ErrorMessage = "Please enter a question")]
            public string Question { get; set; }

            [Required(ErrorMessage = "Please enter a correct answer")]
            public string CorrectAnswer { get; set; }

            [Required(ErrorMessage = "Please enter a 1st wrong answer")]
            public string WrongAnswer1 { get; set; }

            [Required(ErrorMessage = "Please enter a 2nd wrong answer")]
            public string WrongAnswer2 { get; set; }

            [Required(ErrorMessage = "Please enter a 3rd wrong answer")]
            public string WrongAnswer3 { get; set; }

            public int AllNone { get; set; }
        }
    }
}