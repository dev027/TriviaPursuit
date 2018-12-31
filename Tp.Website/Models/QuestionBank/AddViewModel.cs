using Tp.Models.DbEntities;
using Tp.Website.Models.Shared;

namespace Tp.Website.Models.QuestionBank
{
    public class AddViewModel
    {
        public AddViewModel(
            ContentHeaderViewModel contentHeaderViewModel,
            AddQuestionViewModel addQuestionViewModel)
        {
            ContentHeaderViewModel = contentHeaderViewModel;
            AddQuestionViewModel = addQuestionViewModel;
        }

        public ContentHeaderViewModel ContentHeaderViewModel { get; }
        public AddQuestionViewModel AddQuestionViewModel { get; }



        public static AddViewModel Create(Category category)
        {
            return new AddViewModel(
                new ContentHeaderViewModel($"Add {category.Name} Question"),
                AddQuestionViewModel.Create(category));
        }
    }
}