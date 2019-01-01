using Tp.Common.Constants;
using Tp.Common.Extensions.CheeseColourExtensions;
using Tp.Models.DbEntities;

namespace Tp.Website.Models.QuestionBank
{
    public class AddQuestionViewModel
    {
        public AddQuestionViewModel(
            int categoryId,
            string categoryName,
            CheeseColour cheeseColour,
            string question,
            string correctAnswer,
            string wrongAnswer1,
            string wrongAnswer2,
            string wrongAnswer3,
            int allNone,
            bool canEdit)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            IconClass = cheeseColour.ToIconClass();
            BackgroundColourClass = cheeseColour.ToBackgroundColourClass();
            BackgroundDarkColourClass = cheeseColour.ToBackgroundDarkColourClass();
            BorderColourClass = cheeseColour.ToBorderColourClass();
            Question = question;
            CorrectAnswer = correctAnswer;
            WrongAnswer1 = wrongAnswer1;
            WrongAnswer2 = wrongAnswer2;
            WrongAnswer3 = wrongAnswer3;
            AllNone = allNone;
            CanEdit = canEdit;
        }

        public int CategoryId { get; }
        public string CategoryName { get; }
        public string IconClass { get; }
        public string BackgroundColourClass { get; }
        public string BackgroundDarkColourClass { get; }
        public string BorderColourClass { get; }

        public string Question { get; }
        public string CorrectAnswer { get; }
        public string WrongAnswer1 { get; }
        public string WrongAnswer2 { get; }
        public string WrongAnswer3 { get; }
        public int AllNone { get; }

        public bool CanEdit { get; }


        public static AddQuestionViewModel Create(Category category)
        {
            return new AddQuestionViewModel(
                categoryId: category.Id,
                categoryName: category.Name,
                cheeseColour: category.CheeseColour,
                question: "",
                correctAnswer: "",
                wrongAnswer1: "",
                wrongAnswer2: "",
                wrongAnswer3: "",
                allNone: 0,
                canEdit: true);
        }
       public static AddQuestionViewModel Create(
           Category category,
           AddQuestionPostModel addQuestionPostModel)
       {
           return new AddQuestionViewModel(
               categoryId: category.Id,
               categoryName: category.Name,
               cheeseColour: category.CheeseColour,
               question: addQuestionPostModel.Question,
               correctAnswer: addQuestionPostModel.CorrectAnswer,
               wrongAnswer1: addQuestionPostModel.WrongAnswer1,
               wrongAnswer2: addQuestionPostModel.WrongAnswer2,
               wrongAnswer3: addQuestionPostModel.WrongAnswer3,
               allNone: addQuestionPostModel.AllNone,
               canEdit: false);
       }
    }
}