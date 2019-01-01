using Microsoft.AspNetCore.Mvc;
using Tp.Models.DbEntities;
using Tp.Website.Models;
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

        public virtual IActionResult ListByCategory(int categoryId)
        {
            var category = Service.Category.GetById(categoryId);
            var questions = Service.Question.GetByCategoryId(
                categoryId,
                orderBy: Question.OrderBy.IdDescending);
            var model = ListByCategoryViewModel.Create(category, questions);
            return View(model);
        }

    }
}