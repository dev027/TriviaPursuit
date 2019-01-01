using System.Collections.Generic;
using System.Linq;
using Tp.Models.DbEntities;
using Tp.Website.Models.Shared;

namespace Tp.Website.Models.QuestionBank
{
    public class ListByCategoryViewModel
    {
        public ListByCategoryViewModel(
            ContentHeaderViewModel contentHeaderViewModel,
            IDictionary<int, string> questions)
        {
            ContentHeaderViewModel = contentHeaderViewModel;
            Questions = questions;
        }
        public ContentHeaderViewModel ContentHeaderViewModel { get; }

        public IDictionary<int, string> Questions { get; }

        public static ListByCategoryViewModel Create(
            Category category,
            IList<Question> questions)
        {
            return new ListByCategoryViewModel(
                contentHeaderViewModel: new ContentHeaderViewModel(category.Name + " questions"),
                questions: questions.ToDictionary(question => question.Id, question => question.Text));
        }
    }
}