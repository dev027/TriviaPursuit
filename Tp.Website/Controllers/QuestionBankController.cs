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
    }
}