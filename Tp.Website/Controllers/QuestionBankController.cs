using System;
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
        public virtual IActionResult Add(AddQuestionPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Service.Question.Create(
                model.CategoryId,
                model.Question,
                model.CorrectAnswer,
                model.WrongAnswer1,
                model.WrongAnswer2,
                model.WrongAnswer3,
                model.AllNone);

            throw new NotImplementedException();
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